using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace lib12.Utility
{
    /// <summary>
    /// Utility class for calling methods with additional effects.
    /// </summary>
    public static class Execution
    {
        /// <summary>
        /// Repeats calls specified amount of times.
        /// If you pass zero or negative number of calls, action isn't called at all.
        /// </summary>
        /// <param name="times">Number of times to call method</param>
        /// <param name="action">The action to call</param>
        /// <exception cref="ArgumentNullException">action</exception>
        public static void Repeat(int times, Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (times < 1)
                return;

            for (var i = 0; i < times; i++)
                action();
        }

        /// <summary>
        /// Benchmarks performance of given action. Returns how long it took in miliseconds.
        /// </summary>
        /// <param name="action">The action to benchmark</param>
        /// <exception cref="ArgumentNullException">action</exception>
        public static long Benchmark(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Retry action if it fails. If action cannot succeed throws all encountered exceptions in pack.
        /// </summary>
        /// <param name="action">The action to benchmark</param>
        /// <param name="retryInterval">The interval between another action call</param>
        /// <param name="maxAttempts">The maximum number of attempts to call function</param>
        /// <exception cref="ArgumentNullException">action</exception>
        /// <exception cref="ArgumentException">maxAttempts</exception>
        /// <exception cref="ArgumentException">retryInterval</exception>
        /// <exception cref="AggregateException">All aggregated exceptions if all attempts to call function fail</exception>
        public static void Retry(Action action, int retryInterval = 5000, int maxAttempts = 3)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            if (maxAttempts < 1)
                throw new ArgumentException("Must be at least one attempt to call action", nameof(maxAttempts));
            if (retryInterval < 0)
                throw new ArgumentException("Interval between attempts must be non negative", nameof(retryInterval));

            var tryNumber = 1;
            var exceptions = new List<Exception>();
            while (true)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);

                    tryNumber++;
                    if (tryNumber > maxAttempts)
                        throw new AggregateException(exceptions);
                    Thread.Sleep(retryInterval);
                }
            }
        }
    }
}