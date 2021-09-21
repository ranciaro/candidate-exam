using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace unit_tests.Superdigital.Tests.UnitTest
{
    public class TestHost<T> where T : TestStartup
    {
        public TestHost()
        {
            var services = new ServiceCollection();
            var startup = Activator.CreateInstance<T>();
            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();
            startup.ConfigureServices(services, Configuration);
            ServiceProvider = services.BuildServiceProvider();
        }
        protected IServiceProvider ServiceProvider { get; }
        protected IConfiguration Configuration { get; }
    }
    public abstract class TestStartup
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}