using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace FreeSqlBuilderPlanX.Infrastructure.Permission.Helpers
{
    public interface IApiDiscovery
    {

    }

    public class Api
    {
        /// <summary>
        /// API的Url路径
        /// </summary>
        public string UrlPath { get; set; }
        /// <summary>
        /// 请求方法
        /// </summary>
        public HttpMethod Method { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public Module Module { get; set; }
    }

    /// <summary>
    /// 模块
    /// </summary>
    public class Module
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 隶属于模块下的api 
        /// </summary>
        public ICollection<Api> Apis { get; set; }
        /// <summary>
        /// 隶属于模块下的视图（前端目录）
        /// </summary>
        public ICollection<View> Views { get; set; }
    }

    /// <summary>
    /// 前端视图
    /// </summary>
    public class View
    {
        /// <summary>
        /// 名称 (唯一key)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public View Parent { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public ICollection<View> Children { get; set; }
        /// <summary>
        /// 节点路径 （包含所有父节点的id）
        /// </summary>
        public string NodePath { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public Module Module { get; set; }
    }
}