using FreeSql;
using FreeSqlBuilder;
using FreeSqlBuilderPlanX.Infrastructure.Exceptions;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPro.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using DataType = FreeSql.DataType;

namespace WebPortal
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            ExceptionPrompt.IsShowSystemException = true;
            Configuration.Init(config);
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFreeSqlBuilder(x =>
            {
                x.DefaultTemplatePath = "DefaultTemplate";//修改这个配置可以变更模板初始化导入目录（可以指定在本站点根目录的相对路径上)模板也都会从此路径读取
                x.DbSet.DbType = DataType.Sqlite;
                x.DbSet.ConnectionString = "Data Source=fsbuilder.db;Version=3";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "", Version = "v1" });

                c.SwaggerDoc("video", new OpenApiInfo { Title = "视频模块", Version = "v1" });
                c.SwaggerDoc("housemap", new OpenApiInfo { Title = "房源映射模块", Version = "v1" });
                //设置要展示的接口
                c.DocInclusionPredicate((docName, apiDes) =>
                {
                    if (!apiDes.TryGetMethodInfo(out MethodInfo method))
                        return false;
                    /*使用ApiExplorerSettingsAttribute里面的GroupName进行特性标识
                   * DeclaringType只能获取controller上的特性
                   * 我们这里是想以action的特性为主
                  * */
                    var version = method.DeclaringType.GetCustomAttributes(true).OfType<ApiExplorerSettingsAttribute>().Select(m => m.GroupName);
                    if (docName == "v1" && !version.Any())
                        return true;
                    //这里获取action的特性
                    var actionVersion = method.GetCustomAttributes(true).OfType<ApiExplorerSettingsAttribute>().Select(m => m.GroupName);
                    if (actionVersion.Any())
                        return actionVersion.Any(v => v == docName);
                    return version.Any(v => v == docName);
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new[] { "" }
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "权限认证(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                string[] xmlPath = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.AllDirectories);
                foreach (var item in xmlPath)
                {
                    c.IncludeXmlComments(item, true);
                }

            });

            services.AddCors(o => o.AddPolicy("vBen",
                p => p.SetIsOriginAllowed(x => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthorization();
            app.UseCors("vBen");
            //导入默认模板取下面注释
            app.UseDefaultTemplateImport();//初次启动导入模板
            app.UseFreeSqlBuilderUI(o =>
            {
                o.Path = "FreeSqlBuilder";//默认地址为FsGen
                //o.IndexStream=()=> typeof(BuilderUIOptions).GetTypeInfo().Assembly
                //    .GetManifestResourceStream("FreeSql.GeneratorUI.dist.index.html");//如果想要自己编写前端UI可以通过修改这个配置来完成前端替换
            });//使用FreeSqlBuilderUI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "端口模块");
            });
            //调试前端项目可以注释掉FreeSqlBuilderUI并取消下面注释
            //app.UseMvc();
            //app.UseSpa(x => x.UseProxyToSpaDevelopmentServer("http://localhost:4200"));
        }
    }
}
