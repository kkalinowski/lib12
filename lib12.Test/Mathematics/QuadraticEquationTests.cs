using lib12.Mathematics;
using Should;
using Xunit;

namespace lib12.Test.Mathematics
{
    public class QuadraticEquationTests
    {
        [Fact]
        public void no_result_equation()
        {
            var equation = new QuadraticEquation(1, 2, 4);

            equation.ResultType.ShouldEqual(QuadraticEquationResultType.NoResults);
            Assert.Throws<MathException>(() => equation.FirstResult);
            Assert.Throws<MathException>(() => equation.SecondResult);
        }

        [Fact]
        public void one_result_equation()
        {
            var equation = new QuadraticEquation(4, 4, 1);

            equation.ResultType.ShouldEqual(QuadraticEquationResultType.OneResult);
            equation.FirstResult.ShouldEqual(-0.5);
            Assert.Throws<MathException>(() => equation.SecondResult);
        }

        [Fact]
        public void two_results_equation()
        {
            var equation = new QuadraticEquation(-2, 3, -1);

            equation.ResultType.ShouldEqual(QuadraticEquationResultType.TwoResults);
            equation.FirstResult.ShouldEqual(0.5);
            equation.SecondResult.ShouldEqual(1);
        }
    }
}