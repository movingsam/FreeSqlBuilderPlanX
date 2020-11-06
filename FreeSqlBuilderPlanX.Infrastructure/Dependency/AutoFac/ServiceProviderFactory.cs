using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using AutoMapper;
using FreeSqlBuilderPlanX.Infrastructure.Cache;
using FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork;
using FreeSqlBuilderPlanX.Infrastructure.Reflections;
using FreeSqlBuilderPlanX.Infrastructure.Security;
using FreeSqlBuilderPlanX.Infrastructure.Sessions;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using GIMS.Infrastructure.Cache;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ISession = FreeSqlBuilderPlanX.Infrastructure.Sessions.ISession;

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
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISession, Session>();
            var finder = new Finder();
            services.AddSingleton<IFind>(x => finder);
            services.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            services.AddSingleton<ICache, MemoryCache>();
            if (Configuration.Configurations != null)
            {
                services.AddSingleton(Configuration.Configurations);
            }

            var jwt = Configuration.Configurations?.GetSection(nameof(JwtSetting)).Get<JwtSetting>() ?? throw new ArgumentNullException(nameof(JwtSetting), "appsettings.json未找到JwtSetting节点");
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ClockSkew = TimeSpan.FromSeconds(60),
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = jwt.Audience,//Audience
                    ValidIssuer = jwt.Issuer,//Issuer，这两项和前面签发jwt的设置一致
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecurityKey))//拿到SecurityKey
                };
            });
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
            Utils.Web.Init(serviceProvider);
            return serviceProvider;
        }
    }
}
