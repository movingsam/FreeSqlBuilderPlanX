//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-12 17:28
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{

    ///<summary>
    /// Request
    ///</summary>
    public class ApplicationMenuRequestDto :RequestDto
    {
        public long? ParentId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public bool IsHidden { get; set; }

        [MaxLength(255)]
        public string Icon { get; set; }

        [MaxLength(255)]
        public string Path { get; set; }

     }
}