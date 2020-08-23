namespace FreeSqlBuilderPlanX.Core.Base
{
    public interface IPage
    {
        int PageSize { get; }
        int PageNumber { get; }
        string OrderBy { get; }
    }
}