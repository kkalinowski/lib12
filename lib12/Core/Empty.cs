namespace lib12.Core
{
    /// <summary>
    /// Handles empty objects creation and validation
    /// </summary>
    public static class Empty
    {
        /// <summary>
        /// Returns empty array of given type
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <returns></returns>
        public static T[] Array<T>()
        {
            return new T[0];
        }
    }
}