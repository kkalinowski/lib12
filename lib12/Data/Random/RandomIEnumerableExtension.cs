using System;
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
        /// <param name="source">The collection to return from</param>
        /// <returns></returns>
        public static T GetRandomItem<T>(this IEnumerable<T> source)
        {
            if (source.IsNullOrEmpty())
                throw new ArgumentException("Source collection cannot be null or empty");

            return source.ElementAt(Rand.NextInt(source.Count()));
        }
    }
}
