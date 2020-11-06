//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 16:54
// 创建引擎 FreeSqlBuilder
//*******************************

using System.ComponentModel.DataAnnotations;

namespace FreeSqlBuilderPlanX.Web.Dto.ApplicationMenu
{

    ///<summary>
    /// Request
    ///</summary>
    public class ApplicationMenuRequestDto
    {
        [Required]
        public int Level { get; set; }

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