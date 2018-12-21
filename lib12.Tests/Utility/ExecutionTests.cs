using System;
using System.Threading;
using lib12.Utility;
using Shouldly;
using Xunit;

namespace lib12.Tests.Utility
{
    public class ExecutionTests
    {
        [Fact]
        public void Repeat_is_correct()
        {
            var i = 0;
            const int count = 5;

            Execution.Repeat(count, () => i++);

            i.ShouldBe(count);
        }

        [Fact]
        public void Repeat_is_not_called_when_it_should_be_called_less_than_one_time()
        {
            var i = 0;

            Execution.Repeat(0, () => i++);
            Execution.Repeat(-5, () => i++);

            i.ShouldBe(0);
        }

        [Fact]
        public void Repeat_throws_exception_if_action_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Execution.Repeat(12, null));
        }

        [Fact]
        public void Benchmark_is_correct_for_lambda_expression()
        {
            Execution
                .Benchmark(() => Thread.Sleep(100))
                .ShouldBeGreaterThan(0);
        }
    }
}