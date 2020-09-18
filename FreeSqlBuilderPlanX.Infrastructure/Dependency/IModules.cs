using System;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Infrastructure.Dependency
{
    public interface IModules
    {
        void Configure(IServiceCollection service);
        void CreateServiceProvider(IServiceProvider serviceProvider);
    }
}