using System;
using System.Globalization;
using lib12.Checking;

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
        /// Get the week number according to ISO8601 standard
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns></returns>
        public static int GetWeek(this DateTime source)
        {
            //credits to https://stackoverflow.com/a/11155102/578560
            var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(source);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                source = source.AddDays(3);

            return CultureInfo.InvariantCulture.Calendar
                .GetWeekOfYear(source, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
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

        /// <summary>
        /// Determines whether given datetime is workday.
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns>
        ///   <c>true</c> if the specified source is workday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWorkday(this DateTime source)
        {
            return source.DayOfWeek.IsNotAnyOf(DayOfWeek.Saturday, DayOfWeek.Sunday);
        }

        /// <summary>
        /// Determines whether given datetime is weekend.
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns>
        ///   <c>true</c> if the specified source is weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime source)
        {
            return source.DayOfWeek.IsAnyOf(DayOfWeek.Saturday, DayOfWeek.Sunday);
        }

        /// <summary>
        /// Get the start of week from given date. Takes time into account.
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns></returns>
        public static DateTime GetStartOfWeek(this DateTime source)
        {
            //credits to https://stackoverflow.com/a/38064/578560
            var diff = (7 + (source.DayOfWeek - DayOfWeek.Monday)) % 7;
            return source.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Get the end of week from given date. Takes time into account.
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns></returns>
        public static DateTime GetEndOfWeek(this DateTime source)
        {
            var lastDay = source.GetStartOfWeek().AddDays(6);
            return new DateTime(lastDay.Year, lastDay.Month, lastDay.Day, 23, 59, 59);
        }

        /// <summary>
        /// Get the start of month from given date. Takes time into account.
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns></returns>
        public static DateTime GetStartOfMonth(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, 1);
        }

        /// <summary>
        /// Get the end of month from given date. Takes time into account.
        /// </summary>
        /// <param name="source">The source datetime</param>
        /// <returns></returns>
        public static DateTime GetEndOfMonth(this DateTime source)
        {
            var lastDayInMonth = DateTime.DaysInMonth(source.Year, source.Month);
            return new DateTime(source.Year, source.Month, lastDayInMonth, 23, 59, 59);
        }
    }
}