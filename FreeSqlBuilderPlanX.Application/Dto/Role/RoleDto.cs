//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************
using System;
using System.Collections.Generic;
using FreeSqlBuilderPalanX.Application.Entity;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;

namespace FreeSqlBuilderPlanX.Application.Dto.Role
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Descriptions { get; set; }
        public ICollection<ApplicationUserDto> Users { get; set; }
    }
    }