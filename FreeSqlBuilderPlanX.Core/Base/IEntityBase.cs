using System;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public interface IEntityBase<out TKey> : IKey<TKey>
    {
    }

    public interface IEntityBase : IEntityBase<Guid>
    {

    }
}