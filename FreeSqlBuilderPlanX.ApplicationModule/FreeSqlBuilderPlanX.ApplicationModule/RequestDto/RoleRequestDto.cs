//*******************************
// 创建者 Sam
// 创建日期 2020-08-15 02:33
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.ApplicationModule.RequestDto
{
    
        ///<summary>
        /// Request
        ///</summary>
    public class RoleRequestDto
    {
        public  Guid Id { get; set; }

        public  int Version { get; set; }

        public  DateTimeOffset CreateDate { get; set; }

        public  string CreateBy { get; set; }

        public  DateTimeOffset UpdateDate { get; set; }

        public  string UpdateBy { get; set; }

        public  bool IsDeleted { get; set; }

        public  string Name { get; set; }

        public  string Code { get; set; }

        public  string Descriptions { get; set; }

        public  ICollection<ApplicationUser> Users { get; set; }

     }
}