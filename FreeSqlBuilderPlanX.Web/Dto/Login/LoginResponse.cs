using System.ComponentModel;

namespace FreeSqlBuilderPlanX.Web.Dto.Login
{
    public class LoginResponse
    {
        /// <summary>
        /// 结果
        /// </summary>
        public LoginResult Result { get; set; }
        /// <summary>
        /// Jwt生成结果
        /// </summary>
        public JwtResult JwtResult { get; set; }
    }

    public enum LoginResult
    {
        [Description("成功")]
        Success,
        [Description("用户不存在")]
        NoUser,
        [Description("密码错误")]
        PasswordError,
        [Description("失败")]
        Failed
    }
}