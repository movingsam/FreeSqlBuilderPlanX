//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 18:05
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Web.Controller;
using FreeSqlBuilderPlanX.Web.Dto.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.Controller
{

    ///<summary>
    /// 服务
    ///</summary>
    public class ApplicationUserController : ApiControllerBase
    {
        private IApplicationUserIService _service => HttpContext.RequestServices.GetService<IApplicationUserIService>();
        private ILogger Logger =>  HttpContext.RequestServices.GetService<ILogger<ApplicationUserController>>();
        
        ///<summary>
        /// 构造函数
        ///</summary>
        public ApplicationUserController()
        {
        }
        
        ///<summary>
        /// 分页查询
        ///</summary>
        [HttpGet("Page")]
        public async Task<IActionResult> GetPage(ApplicationUserPageRequest request)
        {
            var res= await _service.QueryApplicationUserPage(request);
            return Success(res);
        }

        
        ///<summary>
        /// 查询
        ///</summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var res= await _service.QueryApplicationUser(Id);
            return Success(res);
        }
        
        ///<summary>
        /// 新增
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> New([FromBody]ApplicationUserRequestDto request)
        {
            var res= await _service.NewApplicationUser(request);
            return Success(res);
        }
        
        ///<summary>
        /// 修改
        ///</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ApplicationUserRequestDto request)
        {
            var res= await _service.UpdateApplicationUser(request);
            return Success(res);
        }
        
        ///<summary>
        /// 删除
        ///</summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var res= await _service.DeleteApplicationUser(Id);
            return Success(res);
        }

    }
}