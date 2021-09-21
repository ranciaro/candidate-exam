using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Superdigital.Tests.Core;
using unit_tests.Superdigital.Tests.UnitTest.ExerciseTree;
using Xunit;

namespace unit_tests.Superdigital.Tests.UnitTest
{
    public class ExerciseThreeUnitTest : TestHost<Startup>
    {
        private readonly ICalculate<IDictionary<int[], int>, int[]> _calculate;
        public ExerciseThreeUnitTest()
        {
             _calculate = ServiceProvider.GetRequiredService<ICalculate<IDictionary<int[], int>, int[]>>();

        }

        [Theory]
        [InlineData(new int[5] { 2, 4, 3, 6, 2 }, 8, new int[2] {3, 4})]
        [InlineData(new int[5] { 18, 25, 32, 45, 88 }, 43, new int[2] {0, 1})]
        [InlineData(new int[5] { 1, 2, 3, 4, 15 }, 43, new int[2] {-1, -1})]
        public void teste(int[] elements, int target, int[] expectedResult)
        {
            var dictionary = new Dictionary<int[], int>();
            dictionary.Add(elements, target);
            var result = _calculate.Handle(dictionary);
            Assert.Equal(expectedResult, result);
        }
    }
}