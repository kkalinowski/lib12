using FluentAssertions;
using lib12.Mathematics;
using Xunit;

namespace lib12.Test.Mathematics
{
    public class QuadraticEquationTests
    {
        [Fact]
        public void no_result_equation()
        {
            var equation = new QuadraticEquation(1, 2, 4);

            equation.ResultType.Should().Be(QuadraticEquationResultType.NoResults);
            Assert.Throws<MathException>(() => equation.FirstResult);
            Assert.Throws<MathException>(() => equation.SecondResult);
        }

        [Fact]
        public void one_result_equation()
        {
            var equation = new QuadraticEquation(4, 4, 1);

            equation.ResultType.Should().Be(QuadraticEquationResultType.OneResult);
            equation.FirstResult.Should().Be(-0.5);
            Assert.Throws<MathException>(() => equation.SecondResult);
        }

        [Fact]
        public void two_results_equation()
        {
            var equation = new QuadraticEquation(-2, 3, -1);

            equation.ResultType.Should().Be(QuadraticEquationResultType.TwoResults);
            equation.FirstResult.Should().Be(0.5);
            equation.SecondResult.Should().Be(1);
        }
    }
}