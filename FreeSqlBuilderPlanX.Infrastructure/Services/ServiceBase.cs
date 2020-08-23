using System;
using System.Linq.Expressions;
using AutoMapper;
using FreeSql;
using FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork;
using FreeSqlBuilderPlanX.Infrastructure.Sessions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FreeSqlBuilderPlanX.Infrastructure.Services
{
    /// <summary>
    /// 服务基类 仅仅拿到日志和Session对象
    /// </summary>
    public abstract class ServiceBase<T, TContext> : IServiceBase<T> where T : class
    {
        protected ServiceBase(IServiceProvider service, ILogger logger, Expression<Func<T, bool>> filter = null, Func<string, string> asTable = null)
        {
            Log = logger;
            Session = service.GetService<ISession>();
            UowManager = service.GetService<IUnitOfWorkManager>();
            Mapper = service.GetService<IMapper>();
            Uow = service.GetService<IUnitOfWork<TContext>>();
            Repository = Uow.GetGuidRepository(filter, asTable);
        }
        /// <summary>
        /// 仓储
        /// </summary>
        public IBaseRepository<T> Repository { get; }
        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork<TContext> Uow { get; }
        /// <summary>
        /// 日志抽象
        /// </summary>
        protected ILogger Log { get; }
        /// <summary>
        /// 用户会话
        /// </summary>
        protected ISession Session { get; }
        /// <summary>
        /// Mapper
        /// </summary>
        protected IMapper Mapper { get; }
        /// <summary>
        /// 工作单元管理器
        /// </summary>
        protected IUnitOfWorkManager UowManager { get; }
    }
}
