using FreeSqlBuilderPlanX.Core;
using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Application.Entity
{
    public class Permission : EntityBase<long>
    {
        public long MenuId { get; set; }
        public ApplicationMenu Menu { get; set; }
    }
}