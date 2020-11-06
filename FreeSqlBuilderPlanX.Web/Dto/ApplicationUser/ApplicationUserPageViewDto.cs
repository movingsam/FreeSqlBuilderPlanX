//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************using System.Collections;

using System.Collections.Generic;
using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationUser
{

    ///<summary>
    ///</summary>
    public class ApplicationUserPageViewDto : PageViewBase<ApplicationUserDto>
    {
        public ApplicationUserPageViewDto (IEnumerable<ApplicationUserDto> datas,IPage page,long total):base(datas,page,total)
        {
        }
    }
}