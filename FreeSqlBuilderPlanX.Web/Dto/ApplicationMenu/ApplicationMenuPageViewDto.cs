//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-12 17:28
// 创建引擎 FreeSqlBuilder
//*******************************using System.Collections;
using FreeSqlBuilderPlanX.Core.Base;
using System;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{

    ///<summary>
    ///</summary>
    public class ApplicationMenuPageViewDto : PageViewBase<ApplicationMenuDto,Int64>
    {
        public ApplicationMenuPageViewDto (IEnumerable<ApplicationMenuDto> datas,IPage page,long total):base(datas,page,total)
        {
        }
    }
}