using System.Threading;
using lib12.Misc;
using Should;
using Xunit;

namespace lib12.Test.OtherTests
{
    public class PerformanceCheckTests
    {
        private void ToCheck()
        {
            Thread.Sleep(100);
        }

        [Fact]
        public void counter_is_working()
        {
            PerformanceCheck
                .Check(ToCheck)
                .ShouldBeGreaterThan(0);
        }

        [Fact]
        public void counter_is_working_for_lambda_expression()
        {
            PerformanceCheck
                .Check(() => Thread.Sleep(100))
                .ShouldBeGreaterThan(0);
        }
    }
}