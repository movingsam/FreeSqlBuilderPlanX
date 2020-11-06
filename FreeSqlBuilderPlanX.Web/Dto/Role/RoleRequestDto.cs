//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FreeSqlBuilderPlanX.Web.Dto.ApplicationUser;

namespace FreeSqlBuilderPlanX.Web.Dto.Role
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