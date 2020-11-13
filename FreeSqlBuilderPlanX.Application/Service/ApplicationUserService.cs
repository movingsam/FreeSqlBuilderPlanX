//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Infrastructure.Cache;
using FreeSqlBuilderPlanX.Infrastructure.Consts;
using FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac;
using FreeSqlBuilderPlanX.Infrastructure.Exceptions;
using FreeSqlBuilderPlanX.Infrastructure.Security;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using FreeSqlBuilderPlanX.Web.Dto.Login;
using FreeSqlBuilderPlanX.Web.IServices;
using GIMS.Infrastructure.Cache;
using IdentityModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ISession = FreeSqlBuilderPlanX.Infrastructure.Sessions.ISession;

namespace FreeSqlBuilderPlanX.Application.Service
{

    ///<summary>
    /// 服务
    ///</summary>
    public class ApplicationUserService : ServiceBase<ApplicationUser, ApplicationContext>, IApplicationUserIService, ILoginService<ApplicationUser, LoginRequest, LoginResponse>, ISessionStore<ApplicationUserDto>
    {
        private readonly ICache _cache;
        private readonly ISession _session;
        ///<summary>
        /// 构造函数
        ///</summary>
        public ApplicationUserService(IServiceProvider service, ILogger<ApplicationUserService> logger) : base(service, logger)
        {
            _cache = service.GetService<ICache>();
            _session = service.GetService<ISession>();
        }


        ///<summary>
        /// 新增
        ///</summary>
        public async Task<bool> NewApplicationUser(ApplicationUserRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationUser>(dto);
            if (entity.Roles.Count > 0)
            {
                await Repository.SaveManyAsync(entity, nameof(ApplicationUser.Roles));
            }
            await Repository.InsertAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }

        ///<summary>
        /// 修改
        ///</summary>
        public async Task<bool> UpdateApplicationUser(Guid id, ApplicationUserRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationUser>(dto);
            entity.Id = id;
            await Repository.UpdateAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 删除
        ///</summary>
        public async Task<bool> DeleteApplicationUser(Guid id)
        {
            var res = await Repository.DeleteAsync(x => x.Id == id && x.UserName != "admin");
            if (res == 0) throw new Warning("不能删除系统默认用户/用户不存在");
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 分页查询
        ///</summary>
        public async Task<ApplicationUserPageViewDto> QueryApplicationUserPage(ApplicationUserPageRequest request)
        {
            var datas = await Repository
                                    .Select
                                    .IncludeMany(app => app.Roles)
                                    .WhereIf(!string.IsNullOrWhiteSpace(request.UserName), x => x.UserName.Contains(request.UserName))
                                    .WhereIf(!string.IsNullOrWhiteSpace(request.Email), x => x.Email.Contains(request.Email))
                                    .WhereIf(!string.IsNullOrWhiteSpace(request.Phone), x => x.Phone.Contains(request.Phone))
                                    .WhereIf(!string.IsNullOrWhiteSpace(request.Keyword), x => x.UserName.StartsWith(request.Keyword) || x.Phone.StartsWith(request.Keyword))
                                    .OrderByPropertyName(request.OrderParam.PropertyName, request.OrderParam.IsAscending)
                                    .Count(out var total)
                                    .Page(request.PageNumber, request.PageSize)
                                    .ToListAsync();
            var views = Mapper.Map<List<ApplicationUserDto>>(datas);
            var page = new ApplicationUserPageViewDto(views, request, total);
            return page;
        }


        ///<summary>
        /// 查询
        ///</summary>
        public async Task<ApplicationUserDto> QueryApplicationUser(Guid id)
        {
            var data = await Repository.Select.IncludeMany(app => app.Roles)
                                       .Where(x => x.Id == id)
                                       .ToOneAsync();
            var view = Mapper.Map<ApplicationUserDto>(data);
            return view;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var response = new LoginResponse();
            var hashPassword = request.Password.GetMd5Hash();
            var user = await Repository.Select
                .IncludeMany(x => x.Roles)
                .Where(x => x.UserName == request.Username).ToOneAsync();
            if (user == null)
            {
                throw new Warning("用户不存在");
            }
            if (user.HashPassword != hashPassword)
            {
                throw new Warning("密码错误");
            }
            response.JwtResult = GetJwt(user);
            return response;
        }

        private JwtResult GetJwt(ApplicationUser user)
        {
            var id = new ClaimsIdentity(SysConsts.WEB_COOKIES_NAME);
            id.AddClaims(new[] {
                new Claim( JwtClaimTypes.Subject, user.Id.ToString()),
            });
            var jwtSetting = Ioc.Create<JwtSetting>();
            var token = new JwtSecurityToken(
                issuer: jwtSetting.Issuer,
                audience: jwtSetting.Audience,
                signingCredentials: jwtSetting.Credentials,
                claims: id.Claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(jwtSetting.ExpireSeconds)
            );
            var refreshToken = $"{user.Id}{DateTime.UtcNow}".GetMd5Hash();
            var userDto = Mapper.Map<ApplicationUserDto>(user);
            _cache.SetAsync(string.Format(CacheKeyTemplate.UserSession, user.Id.ToString()), userDto, new TimeSpan(0, 0, 0, 1 * 60 * 60));
            var jwt = new JwtResult
            {
                Duration = DateTime.Now.AddSeconds(1 * 60 * 60),
                RefreshToken = refreshToken,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return jwt;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Logout()
        {
            var res = await _cache.RemoveAsync(string.Format(CacheKeyTemplate.UserSession, _session.UserId));
            return res > 0;
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public Task<ApplicationUserDto> GetCurrentUser()
        {
            return _cache.GetOrCreateAsync<ApplicationUserDto>(string.Format(CacheKeyTemplate.UserSession, _session.UserId),
                async (f) =>
                {
                    f.AbsoluteExpirationRelativeToNow = new TimeSpan(0, 0, 0, 2 * 60 * 60);
                    return await QueryApplicationUser(new Guid(_session.UserId));
                });
        }
    }
}