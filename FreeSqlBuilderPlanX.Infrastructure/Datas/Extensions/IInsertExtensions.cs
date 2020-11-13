using System.Threading.Tasks;
using FreeSql;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Infrastructure.Utils;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.Extensions
{
    /// <summary>
    /// IFreeSql插入数据拓展
    /// </summary>
    public static class IInsertExtensions
    {
        /// <summary>
        /// FreeSql树形结构保存
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TpKey"></typeparam>
        /// <param name="freeSql"></param>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static async Task<IInsert<T>> TreeInsertAsync<TContext, T, TKey, TpKey>(this IFreeSql<TContext> freeSql, T treeEntity)
            where T : class, ITree<T, TKey, TpKey>
        {
            T parent = null;
            if (treeEntity.ParentId != null)
            {
                var parentId = ConvertHelper.To<TKey>(treeEntity.ParentId);
                parent = await freeSql.Select<T>().Where(x => x.Id.Equals(parentId)).ToOneAsync();
            }
            treeEntity.NodePath = parent?.NodePath + (parent?.NodePath == null ? "" : ",") + treeEntity.ParentId;
            return freeSql.Insert(treeEntity);
        }
        /// <summary>
        /// FreeSql树形结构保存
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TpKey"></typeparam>
        /// <param name="freeSql"></param>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static IInsert<T> TreeInsert<TContext, T, TKey, TpKey>(this IFreeSql<TContext> freeSql, T treeEntity)
            where T : class, ITree<T, TKey, TpKey>
        {
            return freeSql.TreeInsertAsync<TContext, T, TKey, TpKey>(treeEntity).Result;
        }
        /// <summary>
        /// 仓储树形结构保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TpKey"></typeparam>
        /// <param name="repository"></param>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static async Task<T> TreeInsertAsync<T, TKey, TpKey>(this IBaseRepository<T> repository, T treeEntity)
            where T : class, ITree<T, TKey, TpKey>
        {
            T parent = null;
            if (treeEntity.ParentId != null)
            {
                var parentId = ConvertHelper.To<TKey>(treeEntity.ParentId);
                parent = await repository.Select.Where(x => x.Id.Equals(parentId)).ToOneAsync();
            }
            treeEntity.NodePath = parent?.NodePath + (parent?.NodePath == null ? "" : ",") + treeEntity.ParentId;
            return repository.Insert(treeEntity);
        }
        /// <summary>
        /// 仓储树形结构保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TpKey"></typeparam>
        /// <param name="repository"></param>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static T TreeInsert<T, TKey, TpKey>(this IBaseRepository<T> repository, T treeEntity)
            where T : class, ITree<T, TKey, TpKey>
        {
            return repository.TreeInsertAsync<T, TKey, TpKey>(treeEntity).Result;
        }
    }
}