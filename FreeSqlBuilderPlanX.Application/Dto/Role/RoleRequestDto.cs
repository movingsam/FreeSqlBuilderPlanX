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
using System.Collections.Generic;
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;


namespace FreeSqlBuilderPlanX.Application.Dto.Role
{
    
        ///<summary>
        /// Request
        ///</summary>
    public class RoleRequestDto
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Code { get; set; }

        [MaxLength(255)]
        public string Descriptions { get; set; }

        public ICollection<ApplicationUserRequestDto> Users { get; set; }

     }
}