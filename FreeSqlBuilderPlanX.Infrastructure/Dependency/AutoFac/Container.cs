using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac
{
    public class Container : IContainer
    {
        private Autofac.IContainer _container;

        public IServiceProvider CreateServiceProvider(ContainerBuilder builder)
        {
            _container = builder.Build();
            return new AutofacServiceProvider(_container);
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public List<T> CreateList<T>(string name = null)
        {
            var result = CreateList(typeof(T), name);
            if (result == null)
                return new List<T>();
            return ((IEnumerable<T>)result).ToList();
        }

        public object CreateList(Type type, string name = null)
        {
            Type serviceType = typeof(IEnumerable<>).MakeGenericType(type);
            return Create(serviceType, name);
        }

        public T Create<T>(string name = null)
        {
            return (T)Create(typeof(T), name);
        }

        public object Create(Type type, string name = null)
        {
            return Utils.Web.HttpContext?.RequestServices != null ? GetServiceFromHttpContext(type, name) : GetService(type, name);
        }
        /// <summary>
        /// 从HttpContext获取服务
        /// </summary>
        private object GetServiceFromHttpContext(Type type, string name)
        {
            var serviceProvider = Utils.Web.HttpContext.RequestServices;
            if (name == null)
                return serviceProvider.GetService(type);
            var context = serviceProvider.GetService<IComponentContext>();
            return context.ResolveNamed(name, type);
        }
        /// <summary>
        /// 获取服务
        /// </summary>
        private object GetService(Type type, string name)
        {
            if (name == null)
                return _container.Resolve(type);
            return _container.ResolveNamed(name, type);
        }
        public AutoFac.IScope BeginScope()
        {
            return new Scope(_container.BeginLifetimeScope());
        }

        public void Register(params IModule[] configs)
        {
            Register(null, null, configs);
        }


        public IServiceProvider Register(IServiceCollection services, params IModule[] configs)
        {
            return Register(services, null, configs);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        public IServiceProvider Register(IServiceCollection services, Action<ContainerBuilder> actionBefore, params IModule[] configs)
        {
            var builder = CreateBuilder(services, actionBefore, configs);
            return CreateServiceProvider(builder);
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前执行的操作</param>
        /// <param name="configs">依赖配置</param>
        public ContainerBuilder CreateBuilder(IServiceCollection services, Action<ContainerBuilder> actionBefore, params IModule[] configs)
        {
            var builder = new ContainerBuilder();
            actionBefore?.Invoke(builder);
            if (configs != null)
            {
                foreach (var config in configs)
                    builder.RegisterModule(config);
            }
            if (services == null)
            {
                services = new ServiceCollection();
                builder.AddSingleton(services);
            }
            builder.Populate(services);
            return builder;
        }
    }
}
