namespace FreeSqlBuilderPlanX.Infrastructure.Consts
{
    public class SysConsts
    {
        /// <summary>
        /// FreeSql节点
        /// </summary>
        public const string FREESQLS = "FreeSqls";
        /// <summary>
        /// 逻辑删除过滤器
        /// </summary>
        public const string DELETED_FILTER = "Delete_Filter";
        /// <summary>
        /// 是否启用过滤器
        /// </summary>
        public const string ENABLED_FILTER = "Enabled_Filter";
        /// <summary>
        /// 跨域节点Key
        /// </summary>
        public const string CORS_SECTION = "Core_Section";
        /// <summary>
        /// 跨域策略
        /// </summary>
        public const string CORS_POLICY = "Cors_Policy";
        /// <summary>
        /// Jwt设置Key
        /// </summary>
        public const string JWT_SETTING_SECTION = "JwtSettingSetion";
        /// <summary>
        /// Cookies
        /// </summary>
        public const string WEB_COOKIES_NAME = "FreeSqlBuilderPlanX";
        /// <summary>
        /// 反射忽略程序集的正则
        /// </summary>
        public const string SKIP_ASSEMBLIES = "^System|^Mscorlib|^msvcr120|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted|^libuv|^api-ms|^clrcompression|^clretwrc|^clrjit|^coreclr|^dbgshim|^e_sqlite3|^hostfxr|^hostpolicy|^MessagePack|^mscordaccore|^mscordbi|^mscorrc|sni|sos|SOS.NETCore|^sos_amd64|^SQLitePCLRaw|^StackExchange|^Swashbuckle|WindowsBase|ucrtbase|^DotNetCore.CAP|^MongoDB|^Confluent.Kafka|^librdkafka|^EasyCaching|^RabbitMQ|^Consul|^Dapper|^EnyimMemcachedCore|^Pipelines|^DnsClient|^IdentityModel|^zlib|^FreeSql|^Scrutor";
    }
}