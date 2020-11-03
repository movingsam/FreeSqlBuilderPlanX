using System;
using System.Linq;
using FreeSql;
using FreeSqlBuilderPlanX.Core.Base;
using FreeSqlBuilderPlanX.Infrastructure.Consts;
using FreeSqlBuilderPlanX.Infrastructure.Datas.UnitOfWork;
using FreeSqlBuilderPlanX.Infrastructure.Sessions;
using FreeSqlBuilderPlanX.Infrastructure.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace FreeSqlBuilderPlanX.Infrastructure.Datas
{
    public static class FreeSqlExtensions
    {
        /// <summary>
        /// 直接从配置文件读取配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public static void CreateFreeSql<T>(this IServiceCollection service)
        {
            service.AddSingleton(f =>
            {
                var configuration = f.GetService<IConfiguration>();
                var freeSqlconfigCollection = configuration.GetSection(nameof(FreeSqlCollectionConfig)).Get<FreeSqlCollectionConfig>();
                var current = freeSqlconfigCollection?.FreeSqlConfigs?.FirstOrDefault(x => x.Key == typeof(T).Name).Value ?? throw new ArgumentNullException(nameof(FreeSqlCollectionConfig),
                                  $"appSettings.json文件未检测到FreeSql的Key为:{typeof(T).Name}的对象");
                var builder = new FreeSqlBuilder()
                    .UseConnectionString(current.DataType, current.MasterConnection)
                    .UseAutoSyncStructure(current.IsSyncStructure);

                if (current.SlaveConnections.Count > 0)
                {
                    builder.UseSlave(current.SlaveConnections.ToArray());
                }
                var res = builder.Build<T>();
                res.Aop.CurdAfter += (s, e) => Aop_CurdAfter(s, e, f.GetService<ILogger<IFreeSql<T>>>());
                res.Aop.AuditValue += (s, e) => Aop_Auditer(s, e, f);
                res.GlobalFilter.Apply<IDeleted>(SysConsts.DELETED_FILTER, x => !x.IsDeleted);
                res.GlobalFilter.Apply<IEnabled>(SysConsts.ENABLED_FILTER, x => x.Enabled == true);
                return res;
            });

            service.AddScoped<IUnitOfWork<T>, UnitOfWork<T>>();
        }

        private static void Aop_CurdAfter(object sender, FreeSql.Aop.CurdAfterEventArgs e, ILogger logger)
        {
            logger.LogInformation("==============================FreeSql 日 志 ==============================");
            var curdType = "查 询";
            switch (e.CurdType)
            {
                case FreeSql.Aop.CurdType.Select:
                    break;
                case FreeSql.Aop.CurdType.Delete:
                    curdType = "删 除";
                    break;
                case FreeSql.Aop.CurdType.Update:
                    curdType = "更 新";
                    break;
                case FreeSql.Aop.CurdType.Insert:
                    curdType = "新 增";
                    break;
            }
            logger.LogInformation($"==============================FreeSql {curdType} ==============================");
            logger.LogInformation($"==============================执行： ==============================");
            logger.LogInformation($"实体：{e.EntityType.Name}");
            logger.LogInformation($"{e.Sql}");
            logger.LogInformation($"执行时间：{e.ElapsedMilliseconds}");
            logger.LogInformation("==============================FreeSql 日 志 ==============================");
            if (e.Exception != null)
            {
                logger.LogError($"执行Sql错误:{e.Sql}");
                logger.LogError($"错误信息:{e.Exception.Message}");
            }
        }

        private static void Aop_Auditer(object sender, FreeSql.Aop.AuditValueEventArgs e, IServiceProvider service)
        {
            var userId = service.GetService<ISession>()?.UserId ?? "当前用户未登录";
            switch (e.AuditValueType)
            {

                case FreeSql.Aop.AuditValueType.Update:
                    switch (e.Column.CsName)
                    {
                        case nameof(IUpdate.UpdateDate):
                            e.Value = DateTimeOffset.Now;
                            break;
                        case nameof(IUpdate.UpdateBy):
                            e.Value = userId;
                            break;
                    }
                    break;
                case FreeSql.Aop.AuditValueType.Insert:
                    switch (e.Column.CsName)
                    {
                        case nameof(ICreate.CreateDate):
                            e.Value = DateTimeOffset.Now;
                            break;
                        case nameof(ICreate.CreateBy):
                            e.Value = userId;
                            break;
                    }

                    break;
            }
        }
    }
}
