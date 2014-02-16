using System.Collections.Generic;

namespace lib12.Core
{
    /// <summary>
    /// Handles empty objects creation
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

        /// <summary>
        /// Returns empty list of given type
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <returns></returns>
        public static List<T> List<T>()
        {
            return new List<T>(0);
        }
    }
}