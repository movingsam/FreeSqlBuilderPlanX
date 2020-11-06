using System.Collections.Generic;
using System.Linq;

namespace FreeSqlBuilderPlanX.Core.Base
{
    public interface IPage
    {
        int PageSize { get; }
        int PageNumber { get; }
        string OrderByString { get; }
    }

    public struct OrderByStruct
    {
        public OrderByStruct(string orderStr)
        {
            if (string.IsNullOrWhiteSpace(orderStr))
            {
                this.PropertyName = nameof(IKey.Id);
            }
            var items = orderStr?.Split(" ");
            if (items?.Length == 1)
            {
                IsAscending = true;
            }
            PropertyName = items?[0];
            IsAscending = items?[1].ToLower() != "desc";
        }
        public string PropertyName { get; set; }
        public bool IsAscending { get; set; }
    }
    //public interface IOrderBy
    //{
    //    string PropertyName { get; }
    //    bool IsAscending { get; }
    //}
}