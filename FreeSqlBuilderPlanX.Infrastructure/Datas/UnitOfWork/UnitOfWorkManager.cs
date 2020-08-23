using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeSql;

namespace FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        /// <summary>
        /// 工作单元集合
        /// </summary>
        private readonly List<IUnitOfWork> _unitOfWorks;

        /// <summary>
        /// 初始化工作单元管理器
        /// </summary>
        public UnitOfWorkManager()
        {
            _unitOfWorks = new List<IUnitOfWork>();
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        public Task CommitAsync()
        {
            Commit();
            return Task.CompletedTask;
        }


        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public void Register(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (_unitOfWorks.Contains(unitOfWork) == false)
                _unitOfWorks.Add(unitOfWork);
        }

        #region IDisposable Support
        private bool _disposedValue = false; // 要检测冗余调用
        /// <summary>
        /// 释放所有的Uow
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _unitOfWorks.ForEach(u => u?.Dispose());
            }
            _disposedValue = true;
        }
        // 添加此代码以正确实现可处置模式。
        /// <summary>
        /// 释放动作
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
