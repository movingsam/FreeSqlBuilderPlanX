using System;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public class RequestBase<TKey> : IKey<TKey>
    {
        public TKey Id { get; set; }
    }

    public class RequestBase : RequestBase<Guid>
    {

    }
}