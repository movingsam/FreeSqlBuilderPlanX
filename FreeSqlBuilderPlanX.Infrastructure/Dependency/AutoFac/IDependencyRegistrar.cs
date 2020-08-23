using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        void Register(IServiceCollection services);
    }
}
