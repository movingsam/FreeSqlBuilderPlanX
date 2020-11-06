using System.Collections.Generic;
using FreeSql.DataAnnotations;
using FreeSqlBuilderPlanX.Core.Base;

namespace FreeSqlBuilderPlanX.Application.Entity
{
    public class Role : AuditEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Descriptions { get; set; }
        [Navigate(ManyToMany = typeof(UserRole))]
        public ICollection<ApplicationUser> Users { get; set; }

    }
}