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
    public class ApplicationUserRequestDto
    {
        public  Guid Id { get; set; }

        public  int Version { get; set; }

        public  DateTimeOffset CreateDate { get; set; }

        public  string CreateBy { get; set; }

        public  DateTimeOffset UpdateDate { get; set; }

        public  string UpdateBy { get; set; }

        public  bool IsDeleted { get; set; }

        public  string UserName { get; set; }

        public  string HashPassword { get; set; }

        public  DateTime Birthday { get; set; }

        public  Gender Gender { get; set; }

        public  string Email { get; set; }

        public  string Phone { get; set; }

        public  ICollection<Role> Roles { get; set; }

     }
}