//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FreeSqlBuilderPlanX.Web.Dto.Role;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationUser
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
        public FreeSqlBuilderPlanX.Core.Gender Gender { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        public ICollection<RoleRequestDto> Roles { get; set; }

     }
}