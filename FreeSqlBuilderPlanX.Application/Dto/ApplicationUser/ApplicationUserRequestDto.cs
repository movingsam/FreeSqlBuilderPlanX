//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;
using FreeSqlBuilderPlanX.Application.Dto.Role;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    
        ///<summary>
        /// Request
        ///</summary>
    public class ApplicationUserRequestDto
    {
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

        public ICollection<RoleRequestDto> Roles { get; set; }

     }
}