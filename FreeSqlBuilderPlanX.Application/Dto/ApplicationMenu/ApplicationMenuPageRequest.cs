//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:42
// 创建引擎 FreeSqlBuilder
//*******************************

using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu
{
    
        ///<summary>
        /// -分页请求
        ///</summary>
    public class ApplicationMenuPageRequest
    {
        public  long Id { get; set; }
        public  int Version { get; set; }
        public  int Level { get; set; }
        public  long? ParentId { get; set; }
        public  ApplicationMenuPageRequest Parent { get; set; }
        public  ICollection<ApplicationMenuPageRequest> Children { get; set; }
        public  string NodePath { get; set; }
        public  bool IsDeleted { get; set; }
        public  bool Enabled { get; set; }
        public  string Name { get; set; }
        public  string Title { get; set; }
        public  bool IsHidden { get; set; }
        public  string Icon { get; set; }
        public  string Path { get; set; }
        
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