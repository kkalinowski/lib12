using FluentAssertions;
using lib12.Mathematics;
using Xunit;

namespace lib12.Test.MathematicsTests
{
    public class MathExtTests
    {
        [Fact]
        public void factorial_test()
        {
            Assert.Throws<MathException>(() => MathExt.Factorial(-1));
            MathExt.Factorial(0).Should().Be(1);
            MathExt.Factorial(1).Should().Be(1);
            MathExt.Factorial(2).Should().Be(2);
            MathExt.Factorial(5).Should().Be(120);
            MathExt.Factorial(10).Should().Be(3628800);
        }
    }
}