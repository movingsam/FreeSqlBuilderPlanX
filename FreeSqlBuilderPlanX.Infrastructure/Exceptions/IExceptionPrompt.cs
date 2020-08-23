namespace FreeSqlBuilderPlanX.Infrastructure.Exceptions
{
    public interface IExceptionPrompt
    {
        /// <summary>获取异常提示</summary>
        /// <param name="exception">异常</param>
        string GetPrompt(System.Exception exception);
    }
}
