using lib12.Mathematics;
using Shouldly;
using Xunit;

namespace lib12.Tests.Mathematics
{
    public class MathExtTests
    {
        [Theory]
        [InlineData(12, true)]
        [InlineData(9, false)]
        public void is_even_is_correct(int number, bool expectedResult)
        {
            MathExt.IsEven(number).ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(12, false)]
        [InlineData(9, true)]
        public void is_odd_is_correct(int number, bool expectedResult)
        {
            MathExt.IsOdd(number).ShouldBe(expectedResult);
        }
    }
}