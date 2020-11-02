using System.ComponentModel;

namespace FreeSqlBuilderPlanX.Application.Dto.Login
{
    public class LoginResponse
    {
        /// <summary>
        /// 入参
        /// </summary>
        public LoginRequest Request { get; set; }
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