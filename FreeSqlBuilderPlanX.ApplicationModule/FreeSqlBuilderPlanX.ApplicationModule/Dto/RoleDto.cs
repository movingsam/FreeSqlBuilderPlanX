//*******************************
// 创建者 Sam
// 创建日期 2020-08-15 02:33
// 创建引擎 FreeSqlBuilder
//*******************************
using System;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.ApplicationModule.Dto
{
    
        ///<summary>
        /// Dto
        ///</summary>
    public class RoleDto
    {

        ///<summary>
        ///</summary>
        public  int Version { get; set; }


        ///<summary>
        ///</summary>
        public  string CreateBy { get; set; }


        ///<summary>
        ///</summary>
        public  string UpdateBy { get; set; }


        ///<summary>
        ///</summary>
        public  bool IsDeleted { get; set; }


        ///<summary>
        ///</summary>
        public  string Name { get; set; }


        ///<summary>
        ///</summary>
        public  string Code { get; set; }


        ///<summary>
        ///</summary>
        public  string Descriptions { get; set; }

        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}