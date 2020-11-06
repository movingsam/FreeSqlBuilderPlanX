using System;
using System.Net.Http;
using FreeSqlBuilderPlanX.Infrastructure.Dependency.AutoFac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebPortal;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestIoc
{
    public class IocTest
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly HttpClient _client;
        private readonly IHost host;
        protected readonly ITestOutputHelper Output;
        public IocTest(ITestOutputHelper tempOutput)
        {
            Output = tempOutput;
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            Environment.SetEnvironmentVariable("ISUNITTEST", "true");
            var hostBuilder = new HostBuilder()
                    .UseServiceProviderFactory(new ServiceProviderFactory())
                    .ConfigureWebHost(webHost =>
                    {
                        webHost.ConfigureAppConfiguration((c, config) =>
                        {
                            c.HostingEnvironment.EnvironmentName = "Development";
                            config.AddConfiguration(configuration);
                            c.Configuration = configuration;
                        });
                        // Add TestServer
                        webHost.UseTestServer();
                        webHost.UseStartup<Startup>();
                    });
            host = hostBuilder.Start();
            _client = host.GetTestClient();
        }


        [Fact]
        public void Test1()
        {

        }
    }
}
