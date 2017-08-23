using lib12.Mathematics;
using Shouldly;
using Xunit;

namespace lib12.Test.Mathematics
{
    public class QuadraticEquationTests
    {
        [Fact]
        public void no_result_equation()
        {
            var equation = new QuadraticEquation(1, 2, 4);

            equation.ResultType.ShouldBe(QuadraticEquationResultType.NoResults);
            Assert.Throws<MathException>(() => equation.FirstResult);
            Assert.Throws<MathException>(() => equation.SecondResult);
        }

        [Fact]
        public void one_result_equation()
        {
            var equation = new QuadraticEquation(4, 4, 1);

            equation.ResultType.ShouldBe(QuadraticEquationResultType.OneResult);
            equation.FirstResult.ShouldBe(-0.5);
            Assert.Throws<MathException>(() => equation.SecondResult);
        }

        [Fact]
        public void two_results_equation()
        {
            var equation = new QuadraticEquation(-2, 3, -1);

            equation.ResultType.ShouldBe(QuadraticEquationResultType.TwoResults);
            equation.FirstResult.ShouldBe(0.5);
            equation.SecondResult.ShouldBe(1);
        }
    }
}