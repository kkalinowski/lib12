using System;

namespace lib12.Extensions
{
    /// <summary>
    /// Extensions for System.DateTime
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Converts given DateTime to Unix time stamp - number of seconds from 1970-01-01
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimeStamp(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
        }

        /// <summary>
        /// Parse Unix time stamp - number of seconds from 1970-01-01 - to System.DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ParseUnixTimeStamp(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timestamp);
            return dateTime;
        }

        /// <summary>
        /// Check if given DateTime has default, empty value
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsDefault(this DateTime target)
        {
            return target == default(DateTime);
        }

        /// <summary>
        /// Returns a new DateTime objects with added weeks
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <param name="value">The value of weeks to add, can be negative</param>
        /// <returns></returns>
        public static DateTime AddWeeks(this DateTime source, double value)
        {
            return source.AddDays(7 * value);
        }

        /// <summary>
        /// Returns a new DateTime objects with added quarters
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <param name="value">The value of quarters to add, can be negative</param>
        /// <returns></returns>
        public static DateTime AddQuarters(this DateTime source, int value)
        {
            return source.AddMonths(3 * value);
        }

        /// <summary>
        /// Gets standard calendar quarter number
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns></returns>
        public static int GetQuarter(this DateTime source)
        {
            return (int)Math.Ceiling(source.Month / 3.0);
        }

        /// <summary>
        /// Checks if given datetime contains past datetime
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns>
        ///   <c>true</c> if [is in the past] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInThePast(this DateTime source)
        {
            return source < DateTime.Now;
        }

        /// <summary>
        /// Checks if given datetime contains future datetime
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns>
        ///   <c>true</c> if [is in the future] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInTheFuture(this DateTime source)
        {
            return source > DateTime.Now;
        }
    }
}