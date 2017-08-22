using lib12.Mathematics;
using Should;
using Xunit;

namespace lib12.Test.Mathematics
{
    public class MathExtTests
    {
        [Fact]
        public void factorial_test()
        {
            Assert.Throws<MathException>(() => MathExt.Factorial(-1));
            MathExt.Factorial(0).ShouldEqual(1);
            MathExt.Factorial(1).ShouldEqual(1);
            MathExt.Factorial(2).ShouldEqual(2);
            MathExt.Factorial(5).ShouldEqual(120);
            MathExt.Factorial(10).ShouldEqual(3628800);
        }

        [Fact]
        public void binomial_coefficient_test()
        {
            Assert.Throws<MathException>(() => MathExt.BinomialCoefficient(-1, 5));
            Assert.Throws<MathException>(() => MathExt.BinomialCoefficient(1, -5));
            Assert.Throws<MathException>(() => MathExt.BinomialCoefficient(-1, -5));
            MathExt.BinomialCoefficient(6, 6).ShouldEqual(1);
            MathExt.BinomialCoefficient(6, 0).ShouldEqual(1);
            MathExt.BinomialCoefficient(7, 2).ShouldEqual(21);
            MathExt.BinomialCoefficient(1024, 1).ShouldEqual(1024);
        }
    }
}