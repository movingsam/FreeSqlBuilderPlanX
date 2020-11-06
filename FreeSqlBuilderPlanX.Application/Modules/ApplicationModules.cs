using AutoMapper;
using FreeSqlBuilderPlanX.Application.DataSeed;
using FreeSqlBuilderPlanX.Application.DbContext;
using FreeSqlBuilderPlanX.Application.Dto.ApplicationUser;
using FreeSqlBuilderPlanX.Application.Entity;
using FreeSqlBuilderPlanX.Application.Service;
using FreeSqlBuilderPlanX.Infrastructure.Datas;
using FreeSqlBuilderPlanX.Infrastructure.Dependency;
using FreeSqlBuilderPlanX.Infrastructure.Security;
using FreeSqlBuilderPlanX.Web.Dto.Login;
using FreeSqlBuilderPlanX.Web.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using FreeSqlBuilderPlanX.Web.Dto.ApplicationUser;

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
            service.AddScoped<ILoginService<ApplicationUser, LoginRequest, LoginResponse>, ApplicationUserService>();
            service.AddScoped<ISessionStore<ApplicationUserDto>, ApplicationUserService>();
            service.AddAutoMapper(this.GetType());
        }

        public void CreateServiceProvider(IServiceProvider serviceProvider)
        {
            var seed = new ApplicationSeedData(serviceProvider);
            seed.SeedRole();
            seed.SeedUser();
            seed.Commit();
        }
    }
}