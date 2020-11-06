using System;

namespace FreeSqlBuilderPlanX.Application.Entity
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public ApplicationUser User { get; set; }
        public Role Role { get; set; }
    }
}