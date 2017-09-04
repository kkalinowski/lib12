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
        /// Check if strings are equal with matching case
        /// </summary>
        /// <param name="target"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        public static bool EqualsMatchCase(this string target, string toCompare)
        {
            return string.Equals(target, toCompare, StringComparison.Ordinal);
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

        /// <summary>
        /// Indicates whether given string is null or empty
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        /// <summary>
        /// Indicates whether given string is not null and not empty
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsNotNullAndNotEmpty(this string target)
        {
            return !string.IsNullOrEmpty(target);
        }

        /// <summary>
        /// Truncates string to given length
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength">Maximum length of given string</param>
        /// <exception cref="ArgumentOutOfRangeException">maxLength - Truncated string must have at least 1 length</exception>
        /// <returns></returns>
        public static string Truncate(this string text, int maxLength)
        {
            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength), "Truncated string must have at least 1 length");

            var toTruncate = text.Recover();
            return toTruncate.Length <= maxLength ? toTruncate : toTruncate.Substring(0, maxLength);
        }

        /// <summary>
        /// Check if given string contains another using OrdinalIgnoreCase comparison
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck">Text to search</param>
        /// <returns></returns>
        public static bool ContainsIgnoreCase(this string text, string toCheck)
        {
            return text.Recover().IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}