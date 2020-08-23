using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public abstract class AuditEntity<TKey> : EntityBase<TKey>, ICreate, IUpdate, IDeleted
    {
        public DateTimeOffset CreateDate { get; set; }
        [Column(StringLength = 36)]
        public string CreateBy { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        [Column(StringLength = 36, IsNullable = true)]
        public string UpdateBy { get; set; }

        public bool IsDeleted { get; set; }
    }

    public abstract class AuditEntity : AuditEntity<Guid>
    {

    }
}
