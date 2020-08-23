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
    public class ApplicationUserDto
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
        public  string UserName { get; set; }


        ///<summary>
        ///</summary>
        public  string HashPassword { get; set; }


        ///<summary>
        ///</summary>
        public  DateTime Birthday { get; set; }


        ///<summary>
        ///</summary>
        public  Gender Gender { get; set; }


        ///<summary>
        ///</summary>
        public  string Email { get; set; }


        ///<summary>
        ///</summary>
        public  string Phone { get; set; }

        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}