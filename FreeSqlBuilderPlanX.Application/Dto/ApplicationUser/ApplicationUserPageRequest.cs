//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;
using FreeSqlBuilderPlanX.Application.Dto.Role;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    
        ///<summary>
        /// -分页请求
        ///</summary>
    public class ApplicationUserPageRequest
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
        public  FreeSqlBuilderPalanX.Application.Entity.Gender Gender { get; set; }
        public  string Email { get; set; }
        public  string Phone { get; set; }
        public  ICollection<RolePageRequest> Roles { get; set; }
        
        ///<summary>
        /// 关键词
        ///</summary>
        public string Keyword { get; set; }
        
        ///<summary>
        /// 页号
        ///</summary>
        public int PageNumber { get; set; }
        
        ///<summary>
        /// 页码
        ///</summary>
        public int PageSize { get; set;}
     }
}


//*******************************
// 所有属性都带出来 
// 不需要的自行删除
//*******************************