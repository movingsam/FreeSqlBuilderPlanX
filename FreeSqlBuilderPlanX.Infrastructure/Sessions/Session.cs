using FreeSqlBuilderPlanX.Infrastructure.Utils;
using IdentityModel;

namespace FreeSqlBuilderPlanX.Infrastructure.Sessions
{
    public class Session : ISession
    {
        /// <summary>
        /// 空用户会话
        /// </summary>
        public static readonly ISession Null = NullSession.Instance;

        /// <summary>
        /// 用户会话
        /// </summary>
        public static readonly ISession Instance = new Session();

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated =>  Utils.Web.Identity.IsAuthenticated;

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId
        {
            get
            {
                var result = Utils.Web.Identity.GetValue(JwtClaimTypes.Subject);
                return string.IsNullOrWhiteSpace(result) ? Utils.Web.Identity.GetValue(System.Security.Claims.ClaimTypes.NameIdentifier) : result;
            }
        }
    }
    public class NullSession : ISession
    {
        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => false;

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId => string.Empty;

        /// <summary>
        /// 空用户会话实例
        /// </summary>
        public static readonly ISession Instance = new NullSession();
    }
}
