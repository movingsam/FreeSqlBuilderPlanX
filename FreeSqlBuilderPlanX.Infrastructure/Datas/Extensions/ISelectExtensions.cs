using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

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
            var orderParam = new OrderByStruct(page.OrderByString);
            var res = select
                            .Count(out var total)
                            .OrderByPropertyName(orderParam.PropertyName, orderParam.IsAscending)
                            .Page(page.PageNumber, page.PageSize)
                            .ToList<TDto>();
            return new PageViewBase<TDto, TKey>(res, page, total);
        }

        public static async Task<PageViewBase<TDto, TKey>> GetPageAsync<TSource, TDto, TKey>(this ISelect<TSource> select, IPage page)
            where TSource : EntityBase<TKey>
            where TDto : DtoBase<TKey>
        {
            var orderParam = new OrderByStruct(page.OrderByString);
            var res = await select
                                .Count(out var total)
                                .OrderByPropertyName(orderParam.PropertyName, orderParam.IsAscending)
                                .Page(page.PageNumber, page.PageSize)
                                .ToListAsync<TDto>();
            return new PageViewBase<TDto, TKey>(res, page, total);
        }
        /// <summary>
        /// 获取节点相关的树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="PtKey"></typeparam>
        /// <param name="select"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetSingleTreeAsync<T, TKey, PtKey>(this ISelect<T> select, TKey id) where T : class, ITree<T, TKey, PtKey>
        {
            var idStr = id.ToString();
            var res = await select.Where(x => x.Id.Equals(id)).ToOneAsync();
            var parentIds = ConvertHelper.ToList<TKey>(res.NodePath);
            var parentTree = await select.Where(x => parentIds.Contains(x.Id)).ToListAsync();
            var children = await select.Where(x => x.NodePath.Contains(idStr)).ToListAsync();
            parentTree.Add(res);
            parentTree.AddRange(children);
            if (parentTree.ToSingleRoot() is T singleRoot)
            {
                return singleRoot;
            }
            return res;
        }
        
    }
}
