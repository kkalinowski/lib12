using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections.Packing
{
    /// <summary>
    /// Easily packs loose objects into collection
    /// </summary>
    public static class Pack
    {
        /// <summary>
        /// Packs objects into the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static IEnumerable<T> IntoEnumerable<T>(params T[] items)
        {
            foreach (var item in items)
                yield return item;
        }

        /// <summary>
        /// Packs objects into the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static T[] IntoArray<T>(params T[] items)
        {
            return items.ToArray();
        }

        /// <summary>
        /// Packs objects into the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static List<T> IntoList<T>(params T[] items)
        {
            return items.ToList();
        }
    }
}