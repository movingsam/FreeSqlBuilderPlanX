using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using AutoMapper;
using FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork;
using FreeSqlBuilderPlanX.Infrastructure.Reflections;
using FreeSqlBuilderPlanX.Infrastructure.Sessions;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac
{
    /// <summary>
    /// 服务提供器工厂
    /// </summary>
    public class ServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务列表</param>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddSingleton<ISession, Session>();
            var finder = new Finder();
            services.AddSingleton<IFind>(x => finder);
            services.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            if (Configuration.Configurations != null)
            {
                services.AddSingleton(Configuration.Configurations);
            }
            Reflection.FindTypes<IModules>(finder.GetAssemblies().ToArray()).ForEach(module =>
            {
                if (!string.IsNullOrWhiteSpace(module?.FullName))
                {
                    (module.Assembly.CreateInstance(module.FullName) as IModules)?.Configure(services);
                }
            });
            return Bootstrapper.Run(services);
        }

        /// <summary>
        /// 创建服务提供器
        /// </summary>
        /// <param name="containerBuilder">容器生成器</param>
        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            if (containerBuilder == null)
                throw new ArgumentNullException(nameof(containerBuilder));
            var serviceProvider = Ioc.DefaultContainer.CreateServiceProvider(containerBuilder);
            var finder = serviceProvider.GetService<IFind>();
            Reflection.FindTypes<IModules>(finder.GetAssemblies().ToArray()).ForEach(module =>
            {
                if (!string.IsNullOrWhiteSpace(module?.FullName))
                {
                    (module.Assembly.CreateInstance(module.FullName) as IModules)?.CreateServiceProvider(serviceProvider);
                }
            });
            Web.Init(serviceProvider);
            return serviceProvider;
        }
    }
}
