//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationMenu
{
    
        ///<summary>
        /// -分页请求
        ///</summary>
    public class ApplicationMenuPageRequest : PageRequest
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsHidden { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
     }
}


//*******************************
// 所有属性都带出来 
// 不需要的自行删除
//*******************************