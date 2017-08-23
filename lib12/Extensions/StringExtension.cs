using System;

namespace lib12.Extensions
{
    public static class StringExtension
    {
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

        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        public static bool IsNotNullAndNotEmpty(this string target)
        {
            return !string.IsNullOrEmpty(target);
        }
    }
}