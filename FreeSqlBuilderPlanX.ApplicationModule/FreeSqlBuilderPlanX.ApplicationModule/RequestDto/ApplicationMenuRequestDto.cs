//*******************************
// 创建者 Sam
// 创建日期 2020-08-15 02:33
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.ApplicationModule.RequestDto
{
    
        ///<summary>
        /// Request
        ///</summary>
    public class ApplicationMenuRequestDto
    {
        public  long Id { get; set; }

        public  int Version { get; set; }

        public  int Level { get; set; }

        public  long? ParentId { get; set; }

        public  ApplicationMenu Parent { get; set; }

        public  ICollection<ApplicationMenu> Children { get; set; }

        public  string NodePath { get; set; }

        public  bool IsDeleted { get; set; }

        public  bool Enabled { get; set; }

     }
}