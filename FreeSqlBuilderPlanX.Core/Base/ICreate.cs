using System;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public interface ICreate
    {
        DateTimeOffset CreateDate { get; }
        string CreateBy { get; }
    }
}