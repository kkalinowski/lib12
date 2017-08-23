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
        /// Check if given DateTime is empty
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DateTime target)
        {
            return target == default(DateTime);
        }
    }
}