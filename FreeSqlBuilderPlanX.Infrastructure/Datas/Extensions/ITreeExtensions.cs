using System;
using System.Collections.Generic;
using System.Linq;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Infrastructure.Utils;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.Extensions
{
    public static class ITreeExtensions
    {
        /// <summary>
        /// Turn the tree shape Collection into one single root tree shape structure
        /// </summary>
        /// <typeparam name="T">Tree Shape Entity</typeparam>
        /// <typeparam name="TKey">节点Id类型</typeparam>
        /// <typeparam name="PtKey">父节点Id类型</typeparam>
        /// <param name="items">Tree Shape Collection</param>
        /// <returns>Tree shape structure object</returns>
        public static ITree<T, TKey, PtKey> ToSingleRoot<T, TKey, PtKey>(this IEnumerable<ITree<T, TKey, PtKey>> items)
            where T : ITree<T, TKey, PtKey>

        {
            var all = items.ToList();
            if (!all.Any())
            {
                return null;
            }
            var top = all.Where(x => x.ParentId == null).ToList();
            if (top.Count > 1)
            {
                throw new System.Exception("There is more than 1 root of tree");
            }
            if (top.Count == 0)
            {
                throw new System.Exception("Can't find the root of tree");
            }
            ITree<T, TKey, PtKey> root = top.Single();

            Action<ITree<T, TKey, PtKey>> findChildren = null;
            findChildren = current =>
            {
                var children = all.Where(x => x.ParentId.Equals(current.Id)).ToList();
                foreach (var child in children)
                {
                    findChildren(child);
                }
                current.Children = children as ICollection<T>;
            };

            findChildren(root);

            return root;
        }

        /// <summary>
        /// 把树形结构数据的集合转化成多个根结点的树形结构数据
        /// </summary>
        /// <typeparam name="T">树形结构实体</typeparam>
        /// <param name="items">树形结构实体的集合</param>
        /// <returns>多个树形结构实体根结点的集合</returns>
        public static List<ITree<T, TKey, PtKey>> ToMultipleRoots<T, TKey, PtKey>(this IEnumerable<ITree<T, TKey, PtKey>> items)
            where T : ITree<T, TKey, PtKey>
        {
            List<ITree<T, TKey, PtKey>> roots;
            var all = items.ToList();
            if (!all.Any())
            {
                return null;
            }
            var top = all.Where(x => x.ParentId == null && !x.IsDeleted).ToList();
            if (top.Any())
            {
                roots = top;
            }
            else
            {
                return null;
            }

            Action<ITree<T, TKey, PtKey>> findChildren = null;
            findChildren = current =>
            {
                var children = all.Where(x => x.ParentId .Equals( current.Id) && !x.IsDeleted).ToList();
                var temp = new List<ITree<T, TKey, PtKey>>();
                foreach (var child in children)
                {
                    findChildren(child);
                    temp.Add(child);
                }
                current.Children = temp as ICollection<T>;

            };

            roots.ForEach(findChildren);

            return roots;
        }
        /// <summary>
        /// 把树形结构数据的集合转化成多个根结点的树形结构数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="PTkey"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<T> ToMultipleRoots<T, TKey, PTkey>(this IEnumerable<T> items)
           where T : TreeEntityBase<T, TKey, PTkey>, new()
            where TKey : IEquatable<TKey>
        {
            List<T> roots;
            var all = items.ToList();
            if (!all.Any())
            {
                return null;
            }
            var top = all.Where(x => x.ParentId == null && !x.IsDeleted).ToList();
            if (top.Any())
            {
                roots = top;
            }
            else
            {
                return null;
            }

            Action<TreeEntityBase<T, TKey, PTkey>> findChildren = null;
            findChildren = current =>
            {
                var children = all.Where(x => x.ParentId.Equals(current.Id) && !x.IsDeleted).ToList();
                var temp = new List<T>();
                foreach (var child in children)
                {
                    findChildren(child);
                    temp.Add(child);
                }
                current.Children = temp;

            };

            roots.ForEach(findChildren);

            return roots;
        }


        /// <summary>
        /// 将多根节点树形结构变成列表型
        /// </summary>
        public static List<T> MultipleRootToList<T, TKey, PTKey>(this IEnumerable<T> items)
            where T : TreeEntityBase<T, TKey, PTKey>
            where TKey : IEquatable<TKey>
        {
            var all = items.ToList();
            if (!all.Any())
            {
                return null;
            }
            List<T> list = new List<T>();
            Action<T, T> makeSingle = null;
            makeSingle = (current, parent) =>
            {
                if (current.Children != null)
                    foreach (var children in current.Children)
                    {
                        makeSingle(children, current);
                    }

                current.Parent = parent;
                list.Add(current);
            };
            all.ForEach(x => makeSingle(x, null));
            return list;
        }

        /// <summary>
        /// 将多根节点树形结构变成列表型不显示子节点
        /// </summary>
        public static List<T> MultipleRootToListWithoutChildren<T>(this IEnumerable<T> items)
            where T : TreeEntityBase<T>, new()
        {
            var all = items.ToList();
            if (!all.Any())
            {
                return null;
            }
            List<T> list = new List<T>();
            Action<T> makeSingle = null;
            makeSingle = current =>
            {
                foreach (var children in current.Children)
                {
                    makeSingle(children);
                }
                T tempT = current.ToJson().ToObject<T>();
                list.Add(tempT);
            };
            all.ForEach(makeSingle);
            return list;
        }

    }
}


