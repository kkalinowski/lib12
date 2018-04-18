namespace lib12.Mathematics.Extensions
{
    public static class IntExtension
    {
        /// <summary>
        /// Converts int to bool
        /// </summary>
        /// <param name="source">The source int</param>
        /// <returns>True if not zero</returns>
        public static bool ToBool(this int source)
        {
            return source != 0;
        }
    }
}