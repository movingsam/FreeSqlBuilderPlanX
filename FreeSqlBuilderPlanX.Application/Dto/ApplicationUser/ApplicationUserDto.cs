//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FreeSqlBuilderPlanX.Application.Dto.Role;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    public class ApplicationUserDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int Version { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        [MaxLength(36)]
        public string CreateBy { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        [MaxLength(36)]
        public string UpdateBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        [MaxLength(255)]
        public string HashPassword { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public FreeSqlBuilderPalanX.Application.Entity.Gender Gender { get; set; }
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Phone { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
    }
}