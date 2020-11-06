namespace FreeSqlBuilderPlanX.Core.Base
{
    /// <summary>
    /// 排序
    /// </summary>
    public class OrderBy 
    {
        public OrderBy(string propertyName, bool desc = true)
        {
            this.PropertyName = propertyName;
            this.IsAscending = desc;
        }

        public OrderBy()
        {
            this.PropertyName = nameof(IKey.Id);
            this.IsAscending = true;
        }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 是否顺序
        /// </summary>
        public bool IsAscending { get; set; }
    }
}