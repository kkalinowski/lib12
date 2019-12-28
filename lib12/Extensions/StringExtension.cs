using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using lib12.Collections;

namespace lib12.Extensions
{
    /// <summary>
    /// StringExtension
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Check if strings are equal with ignore case
        /// </summary>
        /// <param name="target"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        [Obsolete("Use EqualsCaseInsensitive instead")]
        public static bool EqualsIgnoreCase(this string target, string toCompare)
        {
            return target.Equals(toCompare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Check if strings are equal using ordinal comparison ignoring case
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="toCompare">String to compare</param>
        /// <returns></returns>
        public static bool EqualsCaseInsensitive(this string source, string toCompare)
        {
            return string.Equals(source, toCompare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Check if strings are equal with matching case
        /// </summary>
        /// <param name="target"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        [Obsolete("Use EqualsCaseSensitive instead")]
        public static bool EqualsMatchCase(this string target, string toCompare)
        {
            return string.Equals(target, toCompare, StringComparison.Ordinal);
        }

        /// <summary>
        /// Check if strings are equal using ordinal comparison taking case into account
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="toCompare">String to compare</param>
        /// <returns></returns>
        public static bool EqualsCaseSensitive(this string source, string toCompare)
        {
            return string.Equals(source, toCompare, StringComparison.Ordinal);
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
        public static bool ContainsCaseInsensitive(this string text, string toCheck)
        {
            if (text == null || toCheck == null)
                return false;

            return text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Check if given string contains another using OrdinalIgnoreCase comparison
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck">Text to search</param>
        /// <returns></returns>
        [Obsolete("Use ContainsCaseInsensitive")]
        public static bool ContainsIgnoreCase(this string text, string toCheck)
        {
            if (text == null || toCheck == null)
                return false;

            return text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Remove diacritics from given text
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string text)
        {
            //based on https://stackoverflow.com/a/249126
            var normalizedString = text.Recover().Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var sign in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(sign);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(sign);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Get number of the occurrences of given string in source
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="text">The text to search for</param>
        /// <param name="stringComparison">The string comparison method</param>
        /// <returns></returns>
        public static int GetNumberOfOccurrences(this string source, string text, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty() || text.IsNullOrEmpty())
                return 0;

            var count = 0;
            var position = 0;
            while ((position = source.IndexOf(text, position, stringComparison)) != -1)
            {
                position += text.Length;
                count++;
            }

            return count;
        }

        /// <summary>
        /// Get all  occurrences of given string in source
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="text">The text to search for</param>
        /// <param name="stringComparison">The string comparison method</param>
        /// <returns></returns>
        public static IEnumerable<int> GetAllOccurrences(this string source, string text, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty() || text.IsNullOrEmpty())
                yield break;

            var position = 0;
            while ((position = source.IndexOf(text, position, stringComparison)) != -1)
            {
                yield return position;
                position += text.Length;
            }
        }

        /// <summary>
        /// Capitalizes the strings, specificly the first letter of it.
        /// </summary>
        /// <param name="source">The source string to capitalize</param>
        /// <returns></returns>
        public static string Capitalize(this string source)
        {
            if (source.IsNullOrEmpty())
                return source;

            return source[0].ToString().ToUpper() + source.Substring(1);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of any string from the given collection
        /// in the current instance are replaced with another specified string
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="toReplace">Collection of string to replace</param>
        /// <param name="replaceWith">String to replace with</param>
        /// <returns>New string with replaced characters</returns>
        /// <exception cref="ArgumentNullException">Thrown if source or replaceWith are null</exception>
        public static string ReplaceAll(this string source, IEnumerable<string> toReplace, string replaceWith)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if(replaceWith == null)
                throw new ArgumentNullException(nameof(replaceWith));

            return toReplace.Recover()
                .Aggregate(source, (modifiedText, textToReplace) => modifiedText.Replace(textToReplace, replaceWith));
        }
    }
}