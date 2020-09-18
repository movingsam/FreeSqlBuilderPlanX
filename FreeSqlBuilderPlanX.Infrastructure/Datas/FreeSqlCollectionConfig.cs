using System.Collections.Generic;
using FreeSql;

// ReSharper disable once IdentifierTypo
namespace FreeSqlBuilderPlanX.Infrastructure.Datas
{
    /// <summary>
    /// FreeSql配置集合
    /// </summary>
    public class FreeSqlCollectionConfig
    {
        /// <summary>
        /// FreeSql配置
        /// </summary>
        public IDictionary<string, FreeSqlConfig> FreeSqlConfigs { get; set; }
    }
    /// <summary>
    /// FreeSql配置
    /// </summary>
    public class FreeSqlConfig
    {

        /// <summary>
        /// 主库
        /// </summary>
        public string MasterConnection { get; set; }
        /// <summary>
        /// 从库链接
        /// </summary>
        public List<string> SlaveConnections { get; set; } = new List<string>();
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataType DataType { get; set; }
        /// <summary>
        /// 是否同步数据结构
        /// </summary>
        public bool IsSyncStructure { get; set; } = false;
    }

}
