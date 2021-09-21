using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Superdigital.Tests.Core;

namespace unit_tests.Superdigital.Tests.UnitTest.ExerciseTwo
{
    public class Startup : TestStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ICalculate<double, int>), typeof(CalculateMinimalOperations));
        }
    }
}