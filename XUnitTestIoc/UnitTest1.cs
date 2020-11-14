using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
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
        }
        //public IocTest(ITestOutputHelper tempOutput)
        //{
        //    Output = tempOutput;
        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json").Build();
        //    Environment.SetEnvironmentVariable("ISUNITTEST", "true");
        //    var hostBuilder = new HostBuilder()
        //            .UseServiceProviderFactory(new ServiceProviderFactory())
        //            .ConfigureWebHost(webHost =>
        //            {
        //                webHost.ConfigureAppConfiguration((c, config) =>
        //                {
        //                    c.HostingEnvironment.EnvironmentName = "Development";
        //                    config.AddConfiguration(configuration);
        //                    c.Configuration = configuration;
        //                });
        //                // Add TestServer
        //                webHost.UseTestServer();
        //                webHost.UseStartup<Startup>();
        //            });
        //    host = hostBuilder.Start();
        //    _client = host.GetTestClient();
        //}


        [Fact]
        public void Test1()
        {
            int state = 0;
            int test = 0b00010;
            int test2 = 0b0100;
            int test3 = 0b1000;
            int test4 = 0b10000;
            int test5 = 0b100000;
            state |= test;
            state |= test2;
            state |= test5;
            var result = state & test4;
            int a = 30;
            a |= 6;
            Output.WriteLine(a.ToString());
        }
    }
}
