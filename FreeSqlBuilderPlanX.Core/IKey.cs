using System;

namespace FreeSqlBuilderPlanX.Core
{
    public interface IKey<out TKey>
    {
        TKey Id { get; }
    }

    public interface IKey : IKey<Guid>
    {
    }
}