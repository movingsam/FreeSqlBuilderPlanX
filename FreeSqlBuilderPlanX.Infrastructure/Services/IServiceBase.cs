using AutoMapper;
using FreeSql;
using FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork;
using FreeSqlBuilderPlanX.Infrastructure.Dependency;
using FreeSqlBuilderPlanX.Infrastructure.Sessions;
using Microsoft.Extensions.Logging;

namespace FreeSqlBuilderPlanX.Infrastructure.Services
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public interface IServiceBase<T> : IScope where T : class
    {
        /// <summary>
        /// 仓储
        /// </summary>
        IBaseRepository<T> Repository { get; }
    }
}
