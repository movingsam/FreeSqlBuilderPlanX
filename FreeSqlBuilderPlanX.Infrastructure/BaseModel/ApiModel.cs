using Autofac;
using FreeSqlBuilderPlanX.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace FreeSqlBuilderPlanX.Infrastructure.BaseModel
{
    public class ApiModel : IKey<int>
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 接口地址
        /// </summary>
        public string UrlPath { get; set; }
        /// <summary>
        /// GET/POST/PUT/DELETE
        /// </summary>
        public HttpMethod Method { get; set; }
        /// <summary>
        /// 接口描述 ->取自接口Action上的Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 属于哪个模块
        /// </summary>
        public ModuleModel Module { get; set; }
        /// <summary>
        /// 模块id
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// 允许匿名访问
        /// </summary>
        public bool AllowAnonymous { get; set; }
        /// <summary>
        /// 公开的API但是需要登录
        /// </summary>
        public bool IsPublic { get; set; }
    }
}