using Microsoft.Extensions.Configuration;

namespace FreeSqlBuilderPlanX.Infrastructure.Utils
{
    public static class Configuration
    {
        public static void Init(IConfiguration configuration)
        {
            Configurations = configuration;
        }
        public static IConfiguration Configurations { get; private set; }
    }
}