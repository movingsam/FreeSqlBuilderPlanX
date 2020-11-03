//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{

    ///<summary>
    /// Request
    ///</summary>
    public class ApplicationMenuRequestDto
    {
        [Required]
        public int Level { get; set; }

        public long? ParentId { get; set; }

        public ApplicationMenuRequestDto Parent { get; set; }

        public ICollection<ApplicationMenuRequestDto> Children { get; set; }

        [MaxLength(255)]
        public string NodePath { get; set; }

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