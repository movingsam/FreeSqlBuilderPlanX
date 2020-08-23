using System;
using System.Threading.Tasks;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork
{
    public interface IUnitOfWorkManager : IDisposable
    {
        /// <summary>
        /// 提交
        /// </summary>
        void Commit();
        /// <summary>
        /// 提交
        /// </summary>
        Task CommitAsync();
        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        void Register(FreeSql.IUnitOfWork unitOfWork);
    }
}
