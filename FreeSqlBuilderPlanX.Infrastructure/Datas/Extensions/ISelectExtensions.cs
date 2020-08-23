using System.Threading.Tasks;
using FreeSql;
using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.Extensions
{
    public static class ISelectExtensions
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="select"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static PageViewBase<TDto, TKey> GetPage<TSource, TDto, TKey>(this ISelect<TSource> select, IPage page)
            where TSource : EntityBase<TKey>
            where TDto : DtoBase<TKey>
        {
            var res = select
                .Count(out var total)
                .OrderBy(page.OrderBy)
                .Page(page.PageNumber, page.PageSize)
                .ToList<TDto>();
            return new PageViewBase<TDto, TKey>(res, page, total);
        }

        public static async Task<PageViewBase<TDto, TKey>> GetPageAsync<TSource, TDto, TKey>(this ISelect<TSource> select, IPage page)
            where TSource : EntityBase<TKey>
            where TDto : DtoBase<TKey>
        {
            var res = await select
                .Count(out var total)
                .OrderBy(page.OrderBy)
                .Page(page.PageNumber, page.PageSize)
                .ToListAsync<TDto>();
            return new PageViewBase<TDto, TKey>(res, page, total);
        }
    }
}
