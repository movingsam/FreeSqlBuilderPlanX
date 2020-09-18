//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.Role;
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
    public class RoleService : ServiceBase<Role, ApplicationContext>, IRoleIService
    {

        ///<summary>
        /// 构造函数
        ///</summary>
        public RoleService(IServiceProvider service, ILogger<RoleService> logger) : base(service, logger)
        {
        }


        ///<summary>
        /// 新增
        ///</summary>
        public async Task<bool> NewRole(RoleRequestDto dto)
        {
            var entity = Mapper.Map<Role>(dto);
            await Repository.InsertAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }

        ///<summary>
        /// 修改
        ///</summary>
        public async Task<bool> UpdateRole(RoleRequestDto dto)
        {
            var entity = Mapper.Map<Role>(dto);
            await Repository.UpdateAsync(entity);
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 删除
        ///</summary>
        public async Task<bool> DeleteRole(Guid id)
        {
            await Repository.DeleteAsync(x => x.Id == id);
            await UowManager.CommitAsync();
            return true;
        }
        ///<summary>
        /// 分页查询
        ///</summary>
        public async Task<RolePageViewDto> QueryRolePage(RolePageRequest request)
        {
            var datas = await Repository
                                .Select.IncludeMany(rol => rol.Users)
                                .WhereIf(request.Id != null, x => x.Id == request.Id)
                                .WhereIf(request.Version != null, x => x.Version == request.Version)
                                .WhereIf(!string.IsNullOrWhiteSpace(request.CreateBy), x => x.CreateBy.Contains(request.CreateBy))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.UpdateBy), x => x.UpdateBy.Contains(request.UpdateBy))
                                .WhereIf(request.IsDeleted != null, x => x.IsDeleted == request.IsDeleted)
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), x => x.Name.Contains(request.Name))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), x => x.Code.Contains(request.Code))
                                .WhereIf(!string.IsNullOrWhiteSpace(request.Descriptions), x => x.Descriptions.Contains(request.Descriptions))

                                .Count(out var total)
                                .Page(request.PageNumber, request.PageSize)
                                .ToListAsync();
            var views = Mapper.Map<List<RoleDto>>(datas);
            var page = new RolePageViewDto(views, total, request.PageNumber, request.PageSize);
            return page;
        }


        ///<summary>
        /// 查询
        ///</summary>
        public async Task<RoleDto> QueryRole(Guid Id)
        {
            var data = await Repository.Select.IncludeMany(rol => rol.Users)
                                       .Where(x => x.Id == Id)
                                       .ToOneAsync();
            var view = Mapper.Map<RoleDto>(data);
            return view;
        }
    }
}