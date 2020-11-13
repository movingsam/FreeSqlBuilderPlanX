//*******************************
// 创建者 Movingsam
// 创建日期 2020-11-06 18:05
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Web.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Application.Controller
{

    ///<summary>
    /// 服务
    ///</summary>
    public class ApplicationMenuController : ApiControllerBase
    {
        private IApplicationMenuIService Service => HttpContext.RequestServices.GetService<IApplicationMenuIService>();
        private ILogger Logger => HttpContext.RequestServices.GetService<ILogger<ApplicationMenuController>>();

        ///<summary>
        /// 构造函数
        ///</summary>
        public ApplicationMenuController()
        {
        }

        ///<summary>
        /// 分页查询
        ///</summary>
        [HttpGet("Page")]
        public async Task<IActionResult> GetPage(ApplicationMenuPageRequest request)
        {
            var res = await Service.QueryApplicationMenuPage(request);
            return Success(res);
        }


        ///<summary>
        /// 查询
        ///</summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] long Id)
        {
            var res = await Service.QueryApplicationMenu(Id);
            return Success(res);
        }

        ///<summary>
        /// 新增
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> New([FromBody] ApplicationMenuRequestDto request)
        {
            var res = await Service.NewApplicationMenu(request);
            return Success(res);
        }

        ///<summary>
        /// 修改
        ///</summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] ApplicationMenuRequestDto request)
        {
            var res = await Service.UpdateApplicationMenu(id, request);
            return Success(res);
        }

        ///<summary>
        /// 删除
        ///</summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var res = await Service.DeleteApplicationMenu(Id);
            return Success(res);
        }

    }
}