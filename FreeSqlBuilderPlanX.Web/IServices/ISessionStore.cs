using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Web.IServices
{
    public interface ISessionStore<Dto> where Dto : class
    {
        Task<Dto> GetCurrentUser();
    }
}