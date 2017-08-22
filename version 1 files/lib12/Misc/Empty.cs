using System.Collections.Generic;

namespace lib12.Misc
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

        /// <summary>
        /// Returns empty dictionary of given type
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="TValue">Type of value</typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>(0);
        }

        /// <summary>
        /// Returns empty enumerable of given type
        /// </summary>
        public static IEnumerable<T> Enumerable<T>()
        {
            return System.Linq.Enumerable.Empty<T>();
        }

    }
}