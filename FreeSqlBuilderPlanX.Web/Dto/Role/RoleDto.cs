//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Core.Base;
using System.Collections.Generic;

namespace FreeSqlBuilderPlanX.Web.Dto.Role
{
    public class RoleDto : DtoBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Descriptions { get; set; }
        public ICollection<ApplicationUserDto> Users { get; set; }
    }
}