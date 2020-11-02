using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace FreeSqlBuilderPlanX.Infrastructure.Permission.Helpers
{
    public interface IApiDiscovery
    {

    }

    public class Api
    {
        public string UrlPath { get; set; }
        public HttpMethod Method { get; set; }
        public string Description { get; set; }
    }

    public class Module
    {
        public string UrlPath { get; set; }
        public HttpMethod Method { get; set; }
        public string Description { get; set; }

    }
}