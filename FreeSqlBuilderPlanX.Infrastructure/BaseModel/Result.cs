﻿using System.Threading.Tasks;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FreeSqlBuilderPlanX.Web.Controller
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class WebResult : JsonResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public StateCode Code { get; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// 数据
        /// </summary>
        public dynamic Result { get; }

        /// <summary>
        /// 初始化返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        public WebResult(StateCode code, string message, dynamic data = null) : base(null)
        {
            Code = code;
            Message = message;
            Result = data;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        public override Task ExecuteResultAsync(ActionContext context)
        {
            Value = new
            {
                Code = Code.Value(),
                Message,
                Result
            };
            return base.ExecuteResultAsync(context);
        }
    }
    /// <summary>
    /// 状态码
    /// </summary>
    public enum StateCode
    {  /// <summary>
        /// 成功
        /// </summary>
        Ok = 1,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 2
    }
}