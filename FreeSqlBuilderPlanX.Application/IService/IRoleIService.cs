//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.Dto.Role;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.IService
{

    ///<summary>
    /// 服务
    ///</summary>
    public interface IRoleIService : IServiceBase<Role>
    {


        ///<summary>
        /// 新增
        ///</summary>
        Task<bool> NewRole(RoleRequestDto request);
        ///<summary>
        /// 修改
        ///</summary>
        Task<bool> UpdateRole(RoleRequestDto dto);
        ///<summary>
        /// 删除
        ///</summary>
        Task<bool> DeleteRole(Guid id);
        ///<summary>
        /// 分页查询
        ///</summary>
        Task<RolePageViewDto> QueryRolePage(RolePageRequest request);
        ///<summary>
        /// 查询
        ///</summary>
        Task<RoleDto> QueryRole(Guid id);
    }
}