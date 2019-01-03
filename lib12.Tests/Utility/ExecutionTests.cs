using System;
using System.Threading;
using lib12.Extensions;
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

        [Fact]
        public void Retry_throws_exception_if_action_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Execution.Retry(null));
        }

        [Fact]
        public void Retry_works_for_non_failing_action()
        {
            var count = 0;
            Execution.Retry(() => count++);

            count.ShouldBe(1);
        }

        [Fact]
        public void Retry_when_second_attempt_is_correct()
        {
            var count = 0;
            Execution.Retry(() =>
            {
                count++;
                if (count == 1)
                    throw new Exception();
            }, 0);

            count.ShouldBe(2);
        }

        [Fact]
        public void Retry_when_all_attempts_fail()
        {
            const int attemptsCount = 5;
            var count = 0;

            try
            {
                Execution.Retry(() =>
                {
                    count++;
                    throw new Exception();
                }, 0, attemptsCount);
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.Count.ShouldBe(attemptsCount);
            }

            count.ShouldBe(attemptsCount);
        }
    }
}