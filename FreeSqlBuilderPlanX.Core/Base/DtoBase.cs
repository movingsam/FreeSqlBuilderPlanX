using System;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public abstract class DtoBase<TKey> : IKey<TKey>
    {
        public TKey Id { get; set; }
    }
    public abstract class DtoBase : DtoBase<Guid> { }
}