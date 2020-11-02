using FreeSqlBuilderPlanX.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreeSqlBuilderPlanX.Infrastructure.Controller
{
    [ExceptionHandler]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ApiControllerBase:ControllerBase
    {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual IActionResult Success(dynamic data = null, string message = null)
        {
            if (message == null)
                message = "成功";
            return new Result(StateCode.Ok, message, data);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected virtual IActionResult Fail(string message)
        {
            return new Result(StateCode.Fail, message);
        }
    }
}