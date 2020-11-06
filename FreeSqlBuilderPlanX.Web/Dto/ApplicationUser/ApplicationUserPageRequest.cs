//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using System;
using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationUser
{

    ///<summary>
    /// -分页请求
    ///</summary>
    public class ApplicationUserPageRequest : PageRequest
    {
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public DateTime Birthday { get; set; }
        public FreeSqlBuilderPlanX.Core.Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
     }
}


//*******************************
// 所有属性都带出来 
// 不需要的自行删除
//*******************************