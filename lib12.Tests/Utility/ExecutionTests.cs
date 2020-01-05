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
            Assert.Throws<ArgumentNullException>(() => Execution.Repeat(12, (Action)null));
        }

        [Fact]
        public void Repeat_with_index_is_correct()
        {
            var i = 0;
            const int count = 5;

            Execution.Repeat(count, (index) =>
            {
                i.ShouldBe(index);
                i++;
            });

            i.ShouldBe(count);
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
        public void Retry_calls_onError_action()
        {
            var count = 0;
            var exception = new Exception("test-exception");

            Execution.Retry(() =>
                {
                    count++;
                    if (count == 1)
                        throw exception;
                }, 0, 2, 
                (ex, i) =>
                {
                    ex.ShouldBe(exception);
                    i.ShouldBe(1);
                });

            count.ShouldBe(2);
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

        [Fact]
        public void Retry_with_func_returns_result_of_successful_call()
        {
            var count = 0;
            var result = Execution.Retry(() =>
            {
                count++;
                if (count == 1)
                    throw new Exception();
                else
                    return count;
            },  0);

            count.ShouldBe(2);
            result.ShouldBe(2);
        }

        [Fact]
        public void Memoize0_is_correct()
        {
            const int result = 123;

            var memoize0 = Execution.Memoize0(() => result);

            Execution.Repeat(5, () => memoize0().ShouldBe(result));
        }

        [Fact]
        public void Memoize1_throws_exception_when_null_is_passed_as_function()
        {
            Assert.Throws<ArgumentNullException>(() => Execution.Memoize1((Func<int, int>)null));
        }

        [Fact]
        public void Memoize1_is_correct()
        {
            var calls = 0;
            int func(int param)
            {
                calls++;
                return param % 2;
            }

            var memoize1 = Execution.Memoize1<int, int>(func);

            memoize1(2).ShouldBe(0);
            memoize1(2).ShouldBe(0);
            memoize1(3).ShouldBe(1);
            memoize1(3).ShouldBe(1);
            calls.ShouldBe(2);
        }

        [Fact]
        public void Memoize2_is_correct()
        {
            var calls = 0;
            string func2(string param1, int param2)
            {
                calls++;
                return param1 + param2;
            }

            var memoize2 = Execution.Memoize2<string, int, string>(func2);

            memoize2("test", 2).ShouldBe("test2");
            memoize2("test", 2).ShouldBe("test2");
            memoize2("hello", 58).ShouldBe("hello58");
            memoize2("hello", 58).ShouldBe("hello58");
            calls.ShouldBe(2);
        }
    }
}