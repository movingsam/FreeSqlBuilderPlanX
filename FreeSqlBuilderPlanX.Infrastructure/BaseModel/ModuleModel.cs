using System.Collections;
using System.Collections.Generic;
using FreeSqlBuilderPlanX.Core;

namespace FreeSqlBuilderPlanX.Infrastructure.BaseModel
{
    public class ModuleModel : IKey<int>
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 模块描述
        /// </summary>
        public string ModuleDescription { get; set; }
        /// <summary>
        /// 隶属于此模块的API
        /// </summary>
        public virtual ICollection<ApiModel> Apis { get; set; }
    }
}