using System.Collections.Generic;
using System.Linq;
using lib12.Collections;

namespace lib12.Data.Random
{
    /// <summary>
    /// RandomIEnumerableExtension
    /// </summary>
    public static class RandomIEnumerableExtension
    {
        /// <summary>
        /// Returns a random item from given collection
        /// </summary>
        /// <typeparam name="T">Type of objects in collection</typeparam>
        /// <param name="enumerable">The collection to return from</param>
        /// <returns></returns>
        public static T GetRandomItem<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable.IsNullOrEmpty())
                return default(T);

            return enumerable.ElementAt(Rand.NextInt(enumerable.Count()));
        }
    }
}
