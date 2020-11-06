//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Core.Base;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationMenu
{

    ///<summary>
    ///</summary>
    public class ApplicationMenuPageViewDto : PageViewBase<ApplicationMenuDto, long>
    {
        public ApplicationMenuPageViewDto(IEnumerable<ApplicationMenuDto> datas, IPage page, long total) : base(datas, page, total)
        {
        }
    }
}