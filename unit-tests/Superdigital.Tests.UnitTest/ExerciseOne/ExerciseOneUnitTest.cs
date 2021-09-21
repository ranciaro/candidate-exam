using Microsoft.Extensions.DependencyInjection;
using Superdigital.Tests.Core;
using unit_tests.Superdigital.Tests.UnitTest.ExerciseOne;
using Xunit;

namespace unit_tests.Superdigital.Tests.UnitTest
{
    public class ExerciseOneUnitTest : TestHost<Startup>
    {
        private readonly ICalculate<int, string> _calculate;

        public ExerciseOneUnitTest()
        {
            _calculate = ServiceProvider.GetRequiredService<ICalculate<int, string>>();
        }
        
        [Theory]
        [InlineData(0, "23571")]
        [InlineData(3, "71113")]
        [InlineData(8, "17192")]
        public void GetUntilIndex(int index, string expected)
        {
            var value = _calculate.Handle(index);
            Assert.Equal(expected, value);
        }
    }
}