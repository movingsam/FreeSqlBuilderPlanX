using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FreeSqlBuilderPlanX.Infrastructure.Exceptions;
using FreeSqlBuilderPlanX.Infrastructure.Security;
using Microsoft.AspNetCore.Http;

namespace FreeSqlBuilderPlanX.Infrastructure.Utils
{
    /// <summary>
    /// 系统扩展 - 公共
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 安全获取值，当值为null时，不会抛出异常
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }

        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static int Value(this System.Enum instance)
        {
            if (instance == null)
                return 0;
            return Enum.GetValue(instance.GetType(), instance);
        }

        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <typeparam name="TResult">返回值类型</typeparam>
        /// <param name="instance">枚举实例</param>
        public static TResult Value<TResult>(this System.Enum instance)
        {
            if (instance == null)
                return default(TResult);
            return ConvertHelper.To<TResult>(Value(instance));
        }

        /// <summary>
        /// 获取枚举描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static string Description(this System.Enum instance)
        {
            if (instance == null)
                return string.Empty;
            return Enum.GetDescription(instance.GetType(), instance);
        }

        /// <summary>
        /// 转换为用分隔符连接的字符串
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        public static string Join<T>(this IEnumerable<T> list, string quotes = "", string separator = ",")
        {
            return StringHelper.Join(list, quotes, separator);
        }

        /// <summary>
        /// 获取用户标识声明值
        /// </summary>
        /// <param name="identity">用户标识</param>
        /// <param name="type">声明类型</param>
        public static string GetValue(this ClaimsIdentity identity, string type)
        {
            var claim = identity.FindFirst(type);
            if (claim == null)
                return string.Empty;
            return claim.Value;
        }

        /// <summary>
        /// 获取身份标识
        /// </summary>
        /// <param name="context">Http上下文</param>
        public static ClaimsIdentity GetIdentity(this HttpContext context)
        {
            if (context == null)
                return UnauthenticatedIdentity.Instance;
            if (!(context.User is ClaimsPrincipal principal))
                return UnauthenticatedIdentity.Instance;
            if (principal.Identity is ClaimsIdentity identity)
                return identity;
            return UnauthenticatedIdentity.Instance;
        }
        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(this string input)
        {
            if (input == null)
            {
                return null;
            }

            MD5 md5Hash = MD5.Create();

            // 将输入字符串转换为字节数组并计算哈希数据 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // 创建一个 Stringbuilder 来收集字节并创建字符串 
            StringBuilder sBuilder = new StringBuilder();

            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            // 返回十六进制字符串 
            return sBuilder.ToString();
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>返回32位字符串</returns>
        public static string StringToMd5Hash(string inputString)
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            var sb = new StringBuilder();
            foreach (var t in encryptedBytes)
            {
                sb.AppendFormat("{0:x2}", t);
            }
            return sb.ToString();
        }

        /// <summary>移除末尾字符串</summary>
        /// <param name="value">值</param>
        /// <param name="removeValue">要移除的值</param>
        public static string RemoveEnd(this string value, string removeValue)
        {
            return StringHelper.RemoveEnd(value, removeValue);
        }

        /// <summary>获取异常提示</summary>
        /// <param name="exception">异常</param>
        public static string GetPrompt(this System.Exception exception)
        {
            return ExceptionPrompt.GetPrompt(exception);
        }

        ///// <summary>获取原始异常</summary>
        ///// <param name="exception">异常</param>
        //public static Exception GetRawException(this Exception exception)
        //{
        //    if (exception == null)
        //        return (Exception)null;
        //    AspectInvocationException invocationException = exception as AspectInvocationException;
        //    if (invocationException == null)
        //        return exception;
        //    if (((Exception)invocationException).InnerException == null)
        //        return (Exception)invocationException;
        //    return ((Exception)invocationException).InnerException.GetRawException();
        //}
    }
}
