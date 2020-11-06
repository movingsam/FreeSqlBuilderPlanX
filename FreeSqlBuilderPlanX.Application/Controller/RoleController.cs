//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 18:05
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Web.Controller;
using FreeSqlBuilderPlanX.Web.Dto.Role;
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
    public class RoleController : ApiControllerBase
    {
        private IRoleIService _service => HttpContext.RequestServices.GetService<IRoleIService>();
        private ILogger Logger =>  HttpContext.RequestServices.GetService<ILogger<RoleController>>();
        
        ///<summary>
        /// 构造函数
        ///</summary>
        public RoleController()
        {
        }
        
        ///<summary>
        /// 分页查询
        ///</summary>
        [HttpGet("Page")]
        public async Task<IActionResult> GetPage(RolePageRequest request)
        {
            var res= await _service.QueryRolePage(request);
            return Success(res);
        }

        
        ///<summary>
        /// 查询
        ///</summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var res= await _service.QueryRole(Id);
            return Success(res);
        }
        
        ///<summary>
        /// 新增
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> New([FromBody]RoleRequestDto request)
        {
            var res= await _service.NewRole(request);
            return Success(res);
        }
        
        ///<summary>
        /// 修改
        ///</summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]RoleRequestDto request)
        {
            var res= await _service.UpdateRole(request);
            return Success(res);
        }
        
        ///<summary>
        /// 删除
        ///</summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var res= await _service.DeleteRole(Id);
            return Success(res);
        }

    }
}