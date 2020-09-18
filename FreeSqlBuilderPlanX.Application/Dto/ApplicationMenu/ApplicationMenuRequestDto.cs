//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{
    
        ///<summary>
        /// Request
        ///</summary>
    public class ApplicationMenuRequestDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public int Level { get; set; }

        public long? ParentId { get; set; }

        public ApplicationMenuRequestDto Parent { get; set; }

        public ICollection<ApplicationMenuRequestDto> Children { get; set; }

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