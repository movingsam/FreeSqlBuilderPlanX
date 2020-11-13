using System;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public abstract class DtoBase<TKey> : IKey<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TKey Id { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public int Version { get; set; }
    }
    public abstract class DtoBase : DtoBase<Guid> { }
}