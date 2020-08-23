using System;
using System.Linq.Expressions;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork
{
    public class UnitOfWork<TContext> : FreeSql.UnitOfWork, IUnitOfWork<TContext>
    {
        public string TraceId { get; }
        public UnitOfWork(IServiceProvider service) : base(service.GetService<IFreeSql<TContext>>())
        {
            TraceId = Guid.NewGuid().ToString();
            service.GetService<IUnitOfWorkManager>().Register(this);
        }

        public IBaseRepository<TEntity, Guid> GetGuidRepository<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<string, string> asTable = null) where TEntity : class
        {
            var repo = new GuidRepository<TEntity>(_fsql, filter, asTable) { UnitOfWork = this };
            return repo;
        }

        public IBaseRepository<TEntity, TKey> GetRepository<TEntity, TKey>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            var repo = new DefaultRepository<TEntity, TKey>(_fsql, filter) { UnitOfWork = this };
            return repo;
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            var repo = new DefaultRepository<TEntity, int>(_fsql, filter) { UnitOfWork = this };
            return repo;
        }
    }
}
