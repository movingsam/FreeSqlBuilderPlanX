namespace FreeSqlBuilderPlanX.Infrastructure.Sessions
{
    public interface ISession
    {
        /// <summary>
        /// 是否验证通过
        /// </summary>
        bool IsAuthenticated { get; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        string UserId { get; }
    }
}
