using System;
using System.Text;
using lib12.Misc;

namespace lib12.Data.Dummy
{
    public static class RandomExtension
    {
        /// <summary>
        /// Returns a random boolean value
        /// </summary>
        /// <param name="random">Random object</param>
        /// <returns>Random boolean value</returns>
        public static bool NextBool(this Random random)
        {
            return random.Next(0, 2) == 1;
        }

        /// <summary>
        /// Returns a random boolean value with setted percent for true
        /// </summary>
        /// <param name="random">Random object</param>
        /// <param name="percentForTrue">Percent for generating true value</param>
        /// <returns>Random boolean value</returns>
        public static bool NextBool(this Random random, int percentForTrue)
        {
            return random.Next(1, 101) < percentForTrue;
        }

        /// <summary>
        /// Returns a double value between provided range
        /// </summary>
        /// <param name="random">Random object</param>
        /// <param name="start">Inclusive minimum value</param>
        /// <param name="end">Inclusive maximum value</param>
        /// <returns>Random double value between provided range</returns>
        public static double NextDouble(this Random random, double start, double end)
        {
            return start + random.NextDouble() * (end - start);
        }

        /// <summary>
        /// Returns a lowercase letter
        /// </summary>
        /// <param name="random">Random object</param>
        /// <returns>Lowercase letter</returns>
        public static char NextLowercaseLetter(this Random random)
        {
            return (char)((short)'a' + random.Next(26));
        }

        /// <summary>
        /// Returns a random string
        /// </summary>
        /// <param name="random">Random object</param>
        /// <returns>Random string</returns>
        public static string NextString(this Random random)
        {
            return NextString(random, random.Next(4, 10));
        }

        /// <summary>
        /// Returns a random string with provided length
        /// </summary>
        /// <param name="random">Random object</param>
        /// <param name="length">Returned string length</param>
        /// <returns>Random string with provided length</returns>
        public static string NextString(this Random random, int length)
        {
            var sbuilder = new StringBuilder();
            TimesLoop.Do(length, () => sbuilder.Append(random.NextLowercaseLetter()));
            return sbuilder.ToString();
        }

        /// <summary>
        /// Returns a random DateTime between provided range
        /// </summary>
        /// <param name="random">Random object</param>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <returns>Random DateTime between provided range</returns>
        public static DateTime NextDateTime(this Random random, DateTime from, DateTime to)
        {
            var days = (to - from).TotalDays;
            return from.AddDays(random.NextDouble(0, days));
        }
    }
}
