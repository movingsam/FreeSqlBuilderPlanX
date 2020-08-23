using System;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public interface IUpdate
    {
        DateTimeOffset UpdateDate { get; }
        string UpdateBy { get; }
    }
}