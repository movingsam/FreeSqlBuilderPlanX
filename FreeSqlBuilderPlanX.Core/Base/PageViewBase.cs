using System;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public class PageViewBase<TDto, TKey> : Page where TDto : DtoBase<TKey>
    {
        public PageViewBase(IEnumerable<TDto> list, IPage page, long total)
        {
            List = list;
            PageSize = page.PageSize;
            PageNumber = page.PageNumber;
            OrderByString = page.OrderByString;
            Total = total;  
        }
        public IEnumerable<TDto> List { get; }
        public long Total { get; }
    }

    public class PageViewBase<TDto> : PageViewBase<TDto, Guid> where TDto : DtoBase
    {
        public PageViewBase(IEnumerable<TDto> list, IPage page, long total) : base(list, page, total)
        {
        }
    }
}