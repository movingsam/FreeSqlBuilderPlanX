using System;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Infrastructure.Datas;
using FreeSqlBuilderPlanX.Infrastructure.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Application.Modules
{
    public class ApplicationModules : IModules
    {
        public void Configure(IServiceCollection service)
        {
            service.CreateFreeSql<ApplicationContext>();
        }

        public void CreateServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}