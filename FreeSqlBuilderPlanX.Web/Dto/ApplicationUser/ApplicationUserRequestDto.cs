//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-12 17:28
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{

    ///<summary>
    /// Request
    ///</summary>
    public class ApplicationUserRequestDto :RequestDto
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

     }
}