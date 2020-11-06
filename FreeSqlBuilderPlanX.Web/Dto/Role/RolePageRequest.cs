//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Web.Dto.Role
{

    ///<summary>
    /// -分页请求
    ///</summary>
    public class RolePageRequest : PageRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Descriptions { get; set; }
     }
}


//*******************************
// 所有属性都带出来 
// 不需要的自行删除
//*******************************