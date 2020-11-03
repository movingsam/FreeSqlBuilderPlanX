//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.Dto.Login;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using FreeSqlBuilderPlanX.Infrastructure.Cache;
using FreeSqlBuilderPlanX.Infrastructure.Consts;
using FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac;
using FreeSqlBuilderPlanX.Infrastructure.Security;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using GIMS.Infrastructure.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Application.Service
{

    ///<summary>
    /// 服务
    ///</summary>
    public class ApplicationUserService : ServiceBase<ApplicationUser, ApplicationContext>, IApplicationUserIService, ILoginService, ISessionStore
    {
        private readonly ICache _cache;

        ///<summary>
        /// 构造函数
        ///</summary>
        public ApplicationUserService(IServiceProvider service, ILogger<ApplicationUserService> logger) : base(service, logger)
        {
            _cache = service.GetService<ICache>();
        }


        ///<summary>
        /// 新增
        ///</summary>
        public async Task<bool> NewApplicationUser(ApplicationUserRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationUser>(dto);
            await Repository.InsertAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }

        ///<summary>
        /// 修改
        ///</summary>
        public async Task<bool> UpdateApplicationUser(ApplicationUserRequestDto dto)
        {
            var entity = Mapper.Map<ApplicationUser>(dto);
            await Repository.UpdateAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 删除
        ///</summary>
        public async Task<bool> DeleteApplicationUser(Guid id)
        {
            await Repository.DeleteAsync(x => x.Id == id);
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
                                .Count(out var total)
                                .Page(request.PageNumber, request.PageSize)
                                .ToListAsync();
            var views = Mapper.Map<List<ApplicationUserDto>>(datas);
            var page = new ApplicationUserPageViewDto(views, total, request.PageNumber, request.PageSize);
            return page;
        }


        ///<summary>
        /// 查询
        ///</summary>
        public async Task<ApplicationUserDto> QueryApplicationUser(Guid Id)
        {
            var data = await Repository.Select.IncludeMany(app => app.Roles)
                                       .Where(x => x.Id == Id)
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
                .Where(x => x.UserName == request.UserId).ToOneAsync();
            if (user == null)
            {
                response.Result = LoginResult.NoUser;
                return response;
            }
            if (user.HashPassword != hashPassword)
            {
                response.Result = LoginResult.PasswordError;
                return response;
            }
            response.JwtResult = GetJwt(user);
            return response;
        }

        private JwtResult GetJwt(ApplicationUser user)
        {
            var id = new ClaimsIdentity(SysConsts.WEB_COOKIES_NAME);
            id.AddClaims(new Claim[] {
                new Claim( "UserId", user.Id.ToString()),
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
            var refreshToken = $"{user.Id.ToString()}{DateTime.UtcNow}".GetMd5Hash();
            _cache.SetAsync(string.Format(CacheKeyTemplate.UserSession, user.Id), user, new TimeSpan(0, 0, 0, 1 * 60 * 60));
            return new JwtResult()
            {
                Duration = new DateTime().AddSeconds(1 * 60 * 60),
                RefreshToken = refreshToken,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public Task<bool> LogOut(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}