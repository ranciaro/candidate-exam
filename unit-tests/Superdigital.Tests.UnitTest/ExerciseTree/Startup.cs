using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Superdigital.Tests.Core;

namespace unit_tests.Superdigital.Tests.UnitTest.ExerciseTree
{
    public class Startup : TestStartup
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ICalculate<IDictionary<int[], int>, int[]>), typeof(CalculateIdentifySumPattern));
        }
    }
}