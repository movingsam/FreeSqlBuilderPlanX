using FreeSql;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork
{
    public interface IUnitOfWork<TContext> : FreeSql.IUnitOfWork, IRepositoryUnitOfWork
    {
    }
}
