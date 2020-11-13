using System;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Core.Base
{

    public interface ITree<TParent, out TKey, out PTKey> : IKey<TKey>, IDeleted, IEnabled
        where TParent : ITree<TParent, TKey, PTKey>
    {
        PTKey ParentId { get; }
        TParent Parent { get; }
        ICollection<TParent> Children { get; set; }
        string NodePath { get; set; }
    }

    public interface ITree<TParent> : ITree<TParent, Guid, Guid?>
        where TParent : ITree<TParent>
    {
    }
}