using lib12.Mathematics;
using Shouldly;
using Xunit;

namespace lib12.Tests.Mathematics
{
    public class Math2Tests
    {
        [Theory]
        [InlineData(0, 10, 1)]
        [InlineData(-10, 10, -9)]
        [InlineData(5, 10, 6)]
        [InlineData(9, 10, 0)]
        [InlineData(15, 10, 0)]
        [InlineData(3, 5, 4)]
        public void next_is_correct(int number, int limit, int expectedResult)
        {
            Math2.Next(number, limit).ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(0, 10, 10)]
        [InlineData(-10, 10, 10)]
        [InlineData(5, 10, 4)]
        [InlineData(1, 10, 0)]
        [InlineData(15, 10, 14)]
        [InlineData(3, 5, 2)]
        public void prev_is_correct(int number, int limit, int expectedResult)
        {
            Math2.Prev(number, limit).ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(5, 2, 2.5)]
        [InlineData(10, 2, 5)]
        [InlineData(23, 0, 0)]
        public void DivWithZero_is_correct(double a, double b, double expectedResult)
        {
            Math2.DivWithZero(a, b).ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(12, true)]
        [InlineData(9, false)]
        public void is_even_is_correct(int number, bool expectedResult)
        {
            Math2.IsEven(number).ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(12, false)]
        [InlineData(9, true)]
        public void is_odd_is_correct(int number, bool expectedResult)
        {
            Math2.IsOdd(number).ShouldBe(expectedResult);
        }
    }
}