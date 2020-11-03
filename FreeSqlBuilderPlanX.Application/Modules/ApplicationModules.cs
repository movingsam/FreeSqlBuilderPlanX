using System;
using AutoMapper;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Infrastructure.Datas;
using FreeSqlBuilderPlanX.Infrastructure.Dependency;
using FreeSqlBuilderPlanX.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Application.Modules
{
    public class ApplicationModules : IModules
    {
        public void Configure(IServiceCollection service)
        {
            service.AddSingleton<JwtSetting>(f =>
            {
                var configuration = f.GetService<IConfiguration>();
                return configuration.GetSection(nameof(JwtSetting)).Get<JwtSetting>();
            });
            service.CreateFreeSql<ApplicationContext>();
            service.AddAutoMapper(this.GetType());
        }

        public void CreateServiceProvider(IServiceProvider serviceProvider)
        {
        }
    }
}