using FreeSqlBuilderPlanX.Infrastructure.Utils;
using FreeSqlBuilderPlanX.Web.Controller;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Infrastructure.Exceptions
{
    /// <summary>
    /// 异常处理过滤器
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ExceptionHandlerAttribute>>();
            var error = context.Exception;
            logger.LogError(error.GetPrompt());
            context.Result = new Result(StateCode.Fail, error.GetPrompt());
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            this.OnException(context);
            return Task.CompletedTask;
        }

    }
}
