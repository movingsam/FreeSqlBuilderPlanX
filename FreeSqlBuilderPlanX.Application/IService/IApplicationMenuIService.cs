//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Infrastructure.Services;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.IService
{

    ///<summary>
    /// 服务
    ///</summary>
    public interface IApplicationMenuIService : IServiceBase<ApplicationMenu>
    {


        ///<summary>
        /// 新增
        ///</summary>
        Task<bool> NewApplicationMenu(ApplicationMenuRequestDto request);

        ///<summary>
        /// 修改
        ///</summary>
        Task<bool> UpdateApplicationMenu(long id, ApplicationMenuRequestDto dto);
        ///<summary>
        /// 删除
        ///</summary>
        Task<bool> DeleteApplicationMenu(long id);
        ///<summary>
        /// 分页查询
        ///</summary>
        Task<ApplicationMenuPageViewDto> QueryApplicationMenuPage(ApplicationMenuPageRequest request);


        ///<summary>
        /// 查询
        ///</summary>
        Task<ApplicationMenuDto> QueryApplicationMenu(long id);
    }
}