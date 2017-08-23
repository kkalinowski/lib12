using lib12.Mathematics;
using Shouldly;
using Xunit;

namespace lib12.Test.Mathematics
{
    public class MathExtTests
    {
        [Fact]
        public void factorial_test()
        {
            Assert.Throws<MathException>(() => MathExt.Factorial(-1));
            MathExt.Factorial(0).ShouldBe(1);
            MathExt.Factorial(1).ShouldBe(1);
            MathExt.Factorial(2).ShouldBe(2);
            MathExt.Factorial(5).ShouldBe(120);
            MathExt.Factorial(10).ShouldBe(3628800);
        }

        [Fact]
        public void binomial_coefficient_test()
        {
            Assert.Throws<MathException>(() => MathExt.BinomialCoefficient(-1, 5));
            Assert.Throws<MathException>(() => MathExt.BinomialCoefficient(1, -5));
            Assert.Throws<MathException>(() => MathExt.BinomialCoefficient(-1, -5));
            MathExt.BinomialCoefficient(6, 6).ShouldBe(1);
            MathExt.BinomialCoefficient(6, 0).ShouldBe(1);
            MathExt.BinomialCoefficient(7, 2).ShouldBe(21);
            MathExt.BinomialCoefficient(1024, 1).ShouldBe(1024);
        }
    }
}