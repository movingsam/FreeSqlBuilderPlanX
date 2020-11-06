using System;

namespace FreeSqlBuilderPlanX.Web.Dto.Login
{
    /// <summary>
    /// Jwt结果
    /// </summary>
    public class JwtResult
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        public DateTime Duration { get; set; }
        /// <summary>
        /// 刷新码
        /// </summary>
        public string RefreshToken { get; set; }
    }
}