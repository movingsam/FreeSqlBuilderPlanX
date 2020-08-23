using System;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public class PageViewBase<TDto, TKey> : IPage where TDto : DtoBase<TKey>
    {
        public PageViewBase(IEnumerable<TDto> list, IPage page, long total)
        {
            List = list;
            PageSize = page.PageSize;
            PageNumber = page.PageNumber;
            Total = total;
            OrderBy = page.OrderBy;
        }

        public IEnumerable<TDto> List { get; }
        public int PageSize { get; }
        public int PageNumber { get; }
        public long Total { get; }
        public string OrderBy { get; }
    }

    public class PageViewBase<TDto> : PageViewBase<TDto, Guid> where TDto : DtoBase
    {
        public PageViewBase(IEnumerable<TDto> list, IPage page, long total) : base(list, page, total)
        {
        }
    }
}