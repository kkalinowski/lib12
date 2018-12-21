using System;
using System.Diagnostics;

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
        /// Bnechmarks performance of given action. Returns how long it took in miliseconds.
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
    }
}