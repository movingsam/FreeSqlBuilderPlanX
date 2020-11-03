//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-03 16:59
// 创建引擎 FreeSqlBuilder
//*******************************using System.Collections;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using System;
using FreeSqlBuilderPalanX.Application.Entity;
using System.Collections.Generic;


namespace FreeSqlBuilderPlanX.Application.Dto.ApplicationUser
{
    
        ///<summary>
        ///</summary>
    public class ApplicationUserPageViewDto
    {
        public ApplicationUserPageViewDto (IEnumerable<ApplicationUserDto> datas,long total,int pageNumber=1,int pageSize=10)
        {
            this.Datas = datas;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Total = total;
        }
        
        ///<summary>
        /// 分页数据
        ///</summary>
        public IEnumerable<ApplicationUserDto> Datas { get; set;}
        
        ///<summary>
        /// 页号
        ///</summary>
        public int PageSize { get; set;}
        
        ///<summary>
        /// 页码
        ///</summary>        
        public int PageNumber { get; set;}
        
        ///<summary>
        /// 总数
        ///</summary>
        public long Total { get; set;}
    }
}