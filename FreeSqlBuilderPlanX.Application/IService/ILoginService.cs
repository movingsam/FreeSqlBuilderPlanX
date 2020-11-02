using System.Threading.Tasks;
using FreeSqlBuilderPalanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.Dto.Login;
using FreeSqlBuilderPlanX.Infrastructure.Services;

namespace FreeSqlBuilderPlanX.Application.IService
{
    public interface ILoginService : IServiceBase<ApplicationUser>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginResponse> Login(LoginRequest request);
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        Task<ApplicationUserDto> GetCurrentUser();

        /// <summary>
        /// 通过UserID登出
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> LogOut(string userId);
    }
}