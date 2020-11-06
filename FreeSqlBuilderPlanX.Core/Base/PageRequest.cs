namespace FreeSqlBuilderPlanX.Core.Base
{
    /// <summary>
    /// 分页
    /// </summary>
    public abstract class Page : IPage
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 页号
        /// </summary>
        public int PageNumber { get; set; } = 1;

        public string OrderByString { get; set; }
    }

    /// <summary>
    /// 分页请求
    /// </summary>
    public class PageRequest : Page
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        public OrderByStruct OrderParam => new OrderByStruct(OrderByString);
    }
}