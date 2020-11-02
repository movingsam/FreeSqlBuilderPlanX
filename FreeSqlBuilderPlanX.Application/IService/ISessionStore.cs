using System.Threading.Tasks;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;

namespace FreeSqlBuilderPlanX.Application.IService
{
    public interface ISessionStore
    {
        Task<ApplicationUserDto> GetCurrentUser();
    }
}