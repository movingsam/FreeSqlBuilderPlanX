//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.Dto.Role;
using System;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
    }
}