using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Infrastructure.Exceptions;
using FreeSqlBuilderPlanX.Infrastructure.Utils;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.Extensions
{
    /// <summary>
    /// 更新拓展
    /// </summary>
    public static class IUpdateExtensions
    {
        /// <summary>
        /// 树形结构更新 异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TpKey"></typeparam>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static async Task<int> TreeUpdateAsync<T, TKey, TpKey>(this IBaseRepository<T> repository, TKey id, T treeEntity)
            where T : TreeEntityBase<T, TKey, TpKey>
        {
            var old = await repository.Select.Where(x => x.Id.Equals(id)).ToOneAsync();
            if (old == null)
            {
                throw new Warning($"Id:{id} 的数据不存在");
            }
            var parentId = ConvertHelper.To<TKey>(treeEntity.ParentId);
            T parent = null;
            if (parentId != null)
            {
                parent = await repository.Select.Where(x => x.Id.Equals(parentId)).ToOneAsync();
            }

            treeEntity.Id = id;
            treeEntity.NodePath = parent?.NodePath + (parent?.NodePath == null ? "" : ",") + treeEntity.ParentId;
            if (parent != null && !string.IsNullOrWhiteSpace(old.NodePath))
            {
                if (!old?.ParentId.Equals(parentId) ?? false)
                {
                    await repository
                        .Orm
                        .Update<T>()
                        .Where(x => x.NodePath.StartsWith(old.NodePath) && x.NodePath != old.NodePath)
                        .SetRaw($"NodePath = Replace(NodePath, '{old.NodePath}', '{treeEntity.NodePath}')")
                        .ExecuteAffrowsAsync();
                }
            }
            return await repository.UpdateAsync(treeEntity);
        }
        /// <summary>
        /// 树形结构更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TpKey"></typeparam>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        /// <param name="treeEntity"></param>
        /// <returns></returns>
        public static int TreeUpdate<T, TKey, TpKey>(this IBaseRepository<T> repository, TKey id, T treeEntity)
            where T : TreeEntityBase<T, TKey, TpKey>
        {
            return repository.TreeUpdateAsync<T, TKey, TpKey>(id, treeEntity).Result;
        }

    }
}