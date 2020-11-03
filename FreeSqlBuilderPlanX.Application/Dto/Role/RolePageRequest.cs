//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;


namespace FreeSqlBuilderPlanX.Application.Dto.Role
{
    
        ///<summary>
        /// -分页请求
        ///</summary>
    public class RolePageRequest
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
        public  ICollection<ApplicationUserPageRequest> Users { get; set; }
        
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