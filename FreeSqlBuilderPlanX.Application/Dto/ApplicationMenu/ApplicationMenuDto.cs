//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{
    public class ApplicationMenuDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public int Version { get; set; }
        [Required]
        public int Level { get; set; }
        public long? ParentId { get; set; }
        public ApplicationMenuDto Parent { get; set; }
        public ICollection<ApplicationMenuDto> Children { get; set; }
        [MaxLength(255)]
        public string NodePath { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool Enabled { get; set; }
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