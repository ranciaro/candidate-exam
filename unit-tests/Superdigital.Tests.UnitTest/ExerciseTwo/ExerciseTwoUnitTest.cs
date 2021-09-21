using System.Numerics;
using Microsoft.Extensions.DependencyInjection;
using Superdigital.Tests.Core;
using unit_tests.Superdigital.Tests.UnitTest.ExerciseTwo;
using Xunit;

namespace unit_tests.Superdigital.Tests.UnitTest
{
    public class ExerciseTwoUnitTest : TestHost<Startup>
    {
        private readonly ICalculate<double, int> _calculate;
        public ExerciseTwoUnitTest()
        {
            _calculate = ServiceProvider.GetRequiredService<ICalculate<double, int>>();
        }

        [Theory]
        [InlineData(6, 4)]
        [InlineData(68, 7)]
        [InlineData(1288390, 28)]
        public void Calculate_Minimal_Operations_Should_Be_Equal_Expected(double number, int numberOfOperations)
        {
            var value = _calculate.Handle(number);
            Assert.Equal(numberOfOperations, value);
        }

        [Fact]
        public void Calculate_Minimal_Operations_Should_Be_Equal_Expected_Bigest_Double_Number()
        {
            double number = double.Parse("782682321893789127389172318378297837182287348932749279472394792348923747289374823842789378");
            var value = _calculate.Handle(number);
            Assert.Equal(318, value);
        }
        
        [Fact]
        public void Calculate_Minimal_Operations_Should_Be_Equal_Expected_Bigest_Double_Number_2()
        {
            double number = double.Parse("179769313486231570814527423731704356798070567525844996598917476803157260780028538760589558632766878171540458953514382464234321326889464182768467546703537516986049910576551282076245490090389328944075868508455133942304583236903222948165808559332123348274797826204144723168738177180919299881250404026184124858368");
            var value = _calculate.Handle(number);
            Assert.Equal(1025, value);
        }
    }
}