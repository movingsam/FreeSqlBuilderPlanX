//*******************************
// 创建者 Sam
// 创建日期 2020-08-15 02:33
// 创建引擎 FreeSqlBuilder
//*******************************
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.ApplicationModule.Dto
{
    
        ///<summary>
        /// Dto
        ///</summary>
    public class ApplicationMenuDto
    {

        ///<summary>
        ///</summary>
        public  int Version { get; set; }


        ///<summary>
        ///</summary>
        public  int Level { get; set; }


        ///<summary>
        ///</summary>
        public  long? ParentId { get; set; }


        ///<summary>
        ///</summary>
        public  string NodePath { get; set; }


        ///<summary>
        ///</summary>
        public  bool IsDeleted { get; set; }


        ///<summary>
        ///</summary>
        public  bool Enabled { get; set; }

        public ApplicationMenu Parent { get; set; }
        public ICollection<ApplicationMenu> Children { get; set; }
    }
}