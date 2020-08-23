using System;
using FreeSql.DataAnnotations;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        [Column(IsPrimary = true, IsIdentity = true)]
        public TKey Id { get; set; }
        [Column(IsVersion = true)]
        public int Version { get; set; }
    }

    public abstract class EntityBase : EntityBase<Guid>
    {

    }
}