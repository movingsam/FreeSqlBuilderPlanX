//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using System;
using System.Collections.Generic;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Web.Dto.Role;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationUser
{
    public class ApplicationUserDto : DtoBase
    {
            public string UserName { get; set; }
            public string HashPassword { get; set; }
            public DateTime Birthday { get; set; }
            public FreeSqlBuilderPlanX.Core.Gender Gender { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public ICollection<RoleDto> Roles { get; set; }
    }
}