using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Web.Controller;
using FreeSqlBuilderPlanX.Web.Dto.Login;
using FreeSqlBuilderPlanX.Web.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FreeSqlBuilderPlanX.Web.Dto.ApplicationUser;

namespace FreeSqlBuilderPlanX.Application.Controller
{
    public class LoginController : ApiControllerBase
    {
        private ILoginService<ApplicationUser, LoginRequest, LoginResponse> Service => HttpContext.RequestServices.GetService<ILoginService<ApplicationUser, LoginRequest, LoginResponse>>();
        private ILogger Logger => HttpContext.RequestServices.GetService<ILogger<LoginController>>();
        private ISessionStore<ApplicationUserDto> SessionStore => HttpContext.RequestServices.GetService<ISessionStore<ApplicationUserDto>>();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Success(await Service.Login(request));
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/Logout")]
        public async Task<IActionResult> Logout()
        {
            return Success(await Service.Logout());
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/MyInfo")]
        public async Task<IActionResult> MyInfo()
        {
            return Success(await SessionStore.GetCurrentUser());
        }
    }
}