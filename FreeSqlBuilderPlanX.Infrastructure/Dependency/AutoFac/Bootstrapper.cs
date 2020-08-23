using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using FreeSqlBuilderPlanX.Infrastructure.Reflections;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac
{
    /// <summary>
    /// 依赖引导器
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly IServiceCollection _services;
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly IFind _finder;
        /// <summary>
        /// 程序集列表
        /// </summary>
        private List<Assembly> _assemblies;
        /// <summary>
        /// 容器生成器
        /// </summary>
        private ContainerBuilder _builder;

        /// <summary>
        /// 初始化依赖引导器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="finder">类型查找器</param>
        public Bootstrapper(IServiceCollection services, IFind finder)
        {
            _services = services ?? new ServiceCollection();
            _finder = finder ?? new Finder();
        }

        /// <summary>
        /// 启动引导
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="finder">类型查找器</param>
        public static ContainerBuilder Run(IServiceCollection services = null, IFind finder = null)
        {
            return new Bootstrapper(services, finder).Bootstrap();
        }

        /// <summary>
        /// 启动引导
        /// </summary>
        /// <param name="services">服务集合</param>
        public static ContainerBuilder Run(IServiceCollection services)
        {
            return Run(services, null);
        }

        /// <summary>
        /// 引导
        /// </summary>
        public ContainerBuilder Bootstrap()
        {
            _assemblies = _finder.GetAssemblies();
            return Ioc.DefaultContainer.CreateBuilder(_services, RegisterServices);
        }

        /// <summary>
        /// 注册服务集合
        /// </summary>
        private void RegisterServices(ContainerBuilder builder)
        {
            _builder = builder;
            RegisterInfrastracture();
            RegisterDependency();
        }

        /// <summary>
        /// 注册基础设施
        /// </summary>
        private void RegisterInfrastracture()
        {
            RegisterFinder();
        }



        /// <summary>
        /// 注册类型查找器
        /// </summary>
        private void RegisterFinder()
        {
            _builder.AddSingleton(_finder);
        }



        /// <summary>
        /// 注册事件处理器
        /// </summary>
        private void RegisterEventHandlers(Type handlerType)
        {
            var handlerTypes = GetTypes(handlerType);
            foreach (var handler in handlerTypes)
            {
                _builder.RegisterType(handler).As(handler.FindInterfaces(
                    (filter, criteria) => filter.IsGenericType && ((Type)criteria).IsAssignableFrom(filter.GetGenericTypeDefinition())
                    , handlerType
                )).InstancePerLifetimeScope();
            }
        }

        /// <summary>
        /// 获取类型集合
        /// </summary>
        private Type[] GetTypes(Type type)
        {
            return _finder.Find(type, _assemblies).ToArray();
        }

        /// <summary>
        /// 查找并注册依赖
        /// </summary>
        private void RegisterDependency()
        {
            RegisterSingletonDependency();
            RegisterScopeDependency();
            RegisterTransientDependency();
            ResolveDependencyRegistrar();
        }

        /// <summary>
        /// 注册单例依赖
        /// </summary>
        private void RegisterSingletonDependency()
        {
            _builder.RegisterTypes(GetTypes<ISingleton>()).AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
        }

        /// <summary>
        /// 获取类型集合
        /// </summary>
        private Type[] GetTypes<T>()
        {
            return _finder.Find<T>(_assemblies).ToArray();
        }

        /// <summary>
        /// 注册作用域依赖
        /// </summary>
        private void RegisterScopeDependency()
        {
            _builder.RegisterTypes(GetTypes<Dependency.IScope>()).AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 注册瞬态依赖
        /// </summary>
        private void RegisterTransientDependency()
        {
            _builder.RegisterTypes(GetTypes<ITransient>()).AsImplementedInterfaces().PropertiesAutowired().InstancePerDependency();
        }

        /// <summary>
        /// 解析依赖注册器
        /// </summary>
        private void ResolveDependencyRegistrar()
        {
            var types = GetTypes<IDependencyRegistrar>();
            types.Select(type => Reflection.CreateInstance<IDependencyRegistrar>(type)).ToList().ForEach(t => t.Register(_services));
        }
    }
}
