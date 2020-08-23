using System;
using System.Collections.Generic;
using System.Text;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.Logging;

namespace FreeSqlBuilderPlanX.Infrastructure.Exceptions
{
    /// <summary>应用程序异常</summary>
    public class Warning : System.Exception
    {
        /// <summary>初始化应用程序异常</summary>
        /// <param name="message">错误消息</param>
        public Warning(string message)
          : this(message, (string)null)
        {
        }

        /// <summary>初始化应用程序异常</summary>
        /// <param name="exception">异常</param>
        public Warning(System.Exception exception)
          : this((string)null, (string)null, exception)
        {
        }

        /// <summary>初始化应用程序异常</summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        public Warning(string message, string code)
          : this(message, code, (System.Exception)null)
        {
        }

        /// <summary>初始化应用程序异常</summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        /// <param name="exception">异常</param>
        public Warning(string message, string code, System.Exception exception)
          : base(message ?? "", exception)
        {
            this.Code = code;
        }

        /// <summary>错误码</summary>
        public string Code { get; set; }

        /// <summary>获取错误消息</summary>
        public string GetMessage()
        {
            return Warning.GetMessage((System.Exception)this);
        }

        /// <summary>获取错误消息</summary>
        public static string GetMessage(System.Exception ex)
        {
            StringBuilder result = new StringBuilder();
            foreach (System.Exception exception in (IEnumerable<System.Exception>)Warning.GetExceptions(ex))
                Warning.AppendMessage(result, exception);
            return result.ToString().RemoveEnd(Environment.NewLine);
        }

        /// <summary>添加异常消息</summary>
        private static void AppendMessage(StringBuilder result, System.Exception exception)
        {
            if (exception == null)
                return;
            result.AppendLine(exception.Message);
        }

        /// <summary>获取异常列表</summary>
        public IList<System.Exception> GetExceptions()
        {
            return Warning.GetExceptions((System.Exception)this);
        }

        /// <summary>获取异常列表</summary>
        /// <param name="ex">异常</param>
        public static IList<System.Exception> GetExceptions(System.Exception ex)
        {
            List<System.Exception> result = new List<System.Exception>();
            Warning.AddException(result, ex);
            return (IList<System.Exception>)result;
        }

        /// <summary>添加内部异常</summary>
        private static void AddException(List<System.Exception> result, System.Exception exception)
        {
            if (exception == null)
                return;
            result.Add(exception);
            Warning.AddException(result, exception.InnerException);
        }

        /// <summary>获取友情提示</summary>
        /// <param name="level">日志级别</param>
        public string GetPrompt(LogLevel level)
        {
            if (level == LogLevel.Error)
                return "系统错误";
            return this.Message;
        }
    }
}
