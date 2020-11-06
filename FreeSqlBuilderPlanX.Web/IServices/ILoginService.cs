using System.Threading.Tasks;
using FreeSqlBuilderPlanX.Infrastructure.Services;

namespace FreeSqlBuilderPlanX.Web.IServices
{
    public interface ILoginService<T, in Request, Vm> : IServiceBase<T>
        where T : class
        where Request : class
        where Vm : class
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Vm> Login(Request request);

        /// <summary>
        /// 通过UserID登出
        /// </summary>
        /// <returns></returns>
        Task<bool> Logout();
    }
}