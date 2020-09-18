//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;


namespace FreeSqlBuilderPlanX.Application.Dto.Role
{

    ///<summary>
    /// Request
    ///</summary>
    public class RoleRequestDto
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
        public string Name { get; set; }

        [MaxLength(255)]
        public string Code { get; set; }

        [MaxLength(255)]
        public string Descriptions { get; set; }

        public ICollection<ApplicationUserRequestDto> Users { get; set; }

    }
}