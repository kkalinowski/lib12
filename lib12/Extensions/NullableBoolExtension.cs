using System;

namespace lib12.Extensions
{
    /// <summary>
    /// Nullable Bool Extension
    /// </summary>
    public static class NullableBoolExtension
    {
        /// <summary>
        /// Determines whether nullable bool has true value
        /// </summary>
        /// <param name="source">The object to check</param>
        /// <returns>
        ///   <c>true</c> if the specified source is not null and true; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTrue(this bool? source)
        {
            return source == true;
        }

        /// <summary>
        /// Determines whether nullable bool has false value
        /// </summary>
        /// <param name="source">The object to check</param>
        /// <returns>
        ///   <c>true</c> if the specified source is not null and false; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFalse(this bool? source)
        {
            return source == false;
        }

        /// <summary>
        /// Determines whether nullable bool has not value or false value
        /// </summary>
        /// <param name="source">The object to check</param>
        /// <returns>
        ///   <c>true</c> if the specified source is null or not null and false; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrFalse(this bool? source)
        {
            return !source.HasValue || (source == false);
        }
    }
}