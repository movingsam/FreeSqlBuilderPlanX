//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.IService
{

    ///<summary>
    /// 服务
    ///</summary>
    public interface IApplicationUserIService : IServiceBase<ApplicationUser>
    {


        ///<summary>
        /// 新增
        ///</summary>
        Task<bool> NewApplicationUser(ApplicationUserRequestDto request);

        ///<summary>
        /// 修改
        ///</summary>
        Task<bool> UpdateApplicationUser(Guid id,ApplicationUserRequestDto dto);
        ///<summary>
        /// 删除
        ///</summary>
        Task<bool> DeleteApplicationUser(Guid id);
        ///<summary>
        /// 分页查询
        ///</summary>
        Task<ApplicationUserPageViewDto> QueryApplicationUserPage(ApplicationUserPageRequest request);


        ///<summary>
        /// 查询
        ///</summary>
        Task<ApplicationUserDto> QueryApplicationUser(Guid id);
    }
}