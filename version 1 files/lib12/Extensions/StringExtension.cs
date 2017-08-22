using System;

namespace lib12.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Formats given string with arguments
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="args">The arguments</param>
        /// <returns></returns>
        public static string FormatWith(this string formatString, params object[] args)
        {
            return string.Format(formatString, args);
        }

        /// <summary>
        /// Check if strings are equal with ignore case
        /// </summary>
        /// <param name="target"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string target, string toCompare)
        {
            return target.Equals(toCompare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns empty string if given string is null
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Recover(this string target)
        {
            return target ?? string.Empty;
        }
    }
}