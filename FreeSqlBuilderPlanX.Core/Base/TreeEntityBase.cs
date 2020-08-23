using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;

namespace FreeSqlBuilderPlanX.Core.Base
{
    /// <summary>
    /// 树形结构基类 默认Guid
    /// </summary>
    public abstract class TreeEntityBase<TreeEntity> : TreeEntityBase<TreeEntity, Guid, Guid?>
        where TreeEntity : TreeEntityBase<TreeEntity, Guid, Guid?>
    {
    }

    /// <summary>
    /// 树形结构基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TReeEntity"></typeparam>
    /// <typeparam name="PTKey"></typeparam>
    public abstract class TreeEntityBase<TReeEntity, TKey, PTKey> : EntityBase<TKey>, ITree<TReeEntity, TKey, PTKey>
        where TReeEntity : TreeEntityBase<TReeEntity, TKey, PTKey>
    {
        /// <summary>
        /// 树层级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public virtual PTKey ParentId { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        [Navigate(nameof(ParentId))]
        public TReeEntity Parent { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public ICollection<TReeEntity> Children { get; set; }

        /// <summary>
        /// 节点路径 （包含所有父节点的id）
        /// </summary>
        public string NodePath { get; set; }

        /// <summary>
        /// 逻辑删除标识
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 启停用标识
        /// </summary>
        public bool Enabled { get; set; } = true;
    }
}