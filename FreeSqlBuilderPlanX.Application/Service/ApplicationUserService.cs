//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.Service
{

    ///<summary>
    /// 服务
    ///</summary>
    public class ApplicationUserService : ServiceBase<ApplicationUser, ApplicationContext>, IApplicationUserIService
    {

        ///<summary>
        /// 构造函数
        ///</summary>
        public ApplicationUserService(IServiceProvider service, ILogger<ApplicationUserService> logger) : base(service, logger)
        {
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
                                .Select.IncludeMany(app => app.Roles)
                                .WhereIf(request.Id != null, x => x.Id == request.Id)
                                .WhereIf(request.Version != null, x => x.Version == request.Version)
                                .WhereIf(!string.IsNullOrWhiteSpace(request.CreateBy), x => x.CreateBy.Contains(request.CreateBy))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.UpdateBy), x => x.UpdateBy.Contains(request.UpdateBy))
                                .WhereIf(request.IsDeleted != null, x => x.IsDeleted == request.IsDeleted)
                                .WhereIf(!string.IsNullOrWhiteSpace(request.UserName), x => x.UserName.Contains(request.UserName))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.HashPassword), x => x.HashPassword.Contains(request.HashPassword))
                                .WhereIf(request.Birthday != null, x => x.Birthday == request.Birthday)
                                .WhereIf(request.Gender != null, x => x.Gender == request.Gender)
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
    }
}