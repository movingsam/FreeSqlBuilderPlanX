//*******************************
// 创建者 Movingsam
// 创建日期 2020-09-16 12:41
// 创建引擎 FreeSqlBuilder
//*******************************

using FreeSqlBuilderPlanX.Application.Dto.ApplicationMenu;
using FreeSqlBuilderPlanX.Application.IService;
using FreeSqlBuilderPlanX.Infrastructure.Controller;
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
        private IApplicationMenuIService _service => HttpContext.RequestServices.GetService<IApplicationMenuIService>();
        private ILogger Logger =>  HttpContext.RequestServices.GetService<ILogger<ApplicationMenuController>>();
        
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
            var res= await _service.QueryApplicationMenuPage(request);
            return Success(res);
        }

        
        ///<summary>
        /// 查询
        ///</summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long Id)
        {
            var res= await _service.QueryApplicationMenu(Id);
            return Success(res);
        }
        
        ///<summary>
        /// 新增
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> New(ApplicationMenuRequestDto request)
        {
            var res= await _service.NewApplicationMenu(request);
            return Success(res);
        }
        
        ///<summary>
        /// 修改
        ///</summary>
        [HttpPut]
        public async Task<IActionResult> Update(ApplicationMenuRequestDto request)
        {
            var res= await _service.UpdateApplicationMenu(request);
            return Success(res);
        }
        
        ///<summary>
        /// 删除
        ///</summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var res= await _service.DeleteApplicationMenu(Id);
            return Success(res);
        }

    }
}