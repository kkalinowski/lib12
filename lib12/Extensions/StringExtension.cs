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
    }
}