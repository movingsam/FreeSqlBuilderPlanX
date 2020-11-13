//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-12 17:28
// 创建引擎 FreeSqlBuilder
//*******************************using System.Collections;
using FreeSqlBuilderPlanX.Core.Base;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
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