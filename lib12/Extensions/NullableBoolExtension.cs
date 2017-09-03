using System;

namespace lib12.Extensions
{
    public static class NullableBoolExtension
    {
        /// <summary>
        /// Determines whether the specified nullable is not null and true.
        /// </summary>
        /// <param name="nullable">The nullable to check</param>
        public static bool IsTrue(this Nullable<bool> nullable)
        {
            return nullable.HasValue && nullable.Value;
        }

        /// <summary>
        /// Determines whether the specified nullable is null or not null and true.
        /// </summary>
        /// <param name="nullable">The nullable to check</param>
        public static bool IsTrueOrNull(this Nullable<bool> nullable)
        {
            return !nullable.HasValue || nullable.HasValue && nullable.Value;
        }

        /// <summary>
        /// Determines whether the specified nullable is not null and false.
        /// </summary>
        /// <param name="nullable">The nullable to check</param>
        public static bool IsFalse(this Nullable<bool> nullable)
        {
            return nullable.HasValue && !nullable.Value;
        }

        /// <summary>
        /// Determines whether the specified nullable is null or not null and false.
        /// </summary>
        /// <param name="nullable">The nullable to check</param>
        public static bool IsFalseOrNull(this Nullable<bool> nullable)
        {
            return !nullable.HasValue || !nullable.Value;
        }
    }
}
