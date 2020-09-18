using System;
using System.Collections.Generic;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.Hosting;

namespace FreeSqlBuilderPlanX.Infrastructure.Exceptions
{
    /// <summary>异常提示</summary>
    public static class ExceptionPrompt
    {
        /// <summary>异常提示组件集合</summary>
        private static readonly List<IExceptionPrompt> Prompts = new List<IExceptionPrompt>();

        /// <summary>是否显示系统异常消息</summary>
        public static bool IsShowSystemException { get; set; }

        /// <summary>添加异常提示</summary>
        /// <param name="prompt">异常提示</param>
        public static void AddPrompt(IExceptionPrompt prompt)
        {
            if (prompt == null)
                throw new ArgumentNullException(nameof(prompt));
            if (ExceptionPrompt.Prompts.Contains(prompt))
                return;
            ExceptionPrompt.Prompts.Add(prompt);
        }

        /// <summary>获取异常提示</summary>
        /// <param name="exception">异常</param>
        public static string GetPrompt(System.Exception exception)
        {
            if (exception == null)
                return (string)null;
            string exceptionPrompt = ExceptionPrompt.GetExceptionPrompt(exception);
            if (!string.IsNullOrWhiteSpace(exceptionPrompt))
                return exceptionPrompt;
            if (exception is Warning warning)
                return warning.Message;
            if (Web.Environment.IsDevelopment() || ExceptionPrompt.IsShowSystemException)
                return exception.Message;
            return "系统异常";
        }

        /// <summary>获取异常提示</summary>
        private static string GetExceptionPrompt(System.Exception exception)
        {
            foreach (IExceptionPrompt prompt1 in ExceptionPrompt.Prompts)
            {
                string prompt2 = prompt1.GetPrompt(exception);
                if (!string.IsNullOrWhiteSpace(prompt2))
                    return prompt2;
            }
            return string.Empty;
        }
    }
}
