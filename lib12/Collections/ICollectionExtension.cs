using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections
{
    /// <summary>
    /// ICollectionExtension
    /// </summary>
    public static class ICollectionExtension
    {
        /// <summary>
        /// Add to collection elements from other collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection to add elements to</param>
        /// <param name="toAdd">Elements to add</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> toAdd)
        {
            if(collection == null)
                throw new ArgumentNullException(nameof(collection));

            toAdd
                .Recover()
                .ForEach(collection.Add);
        }

        /// <summary>
        /// Removes from collection elements from other collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection to remove elements from</param>
        /// <param name="toRemove">Elements to remove</param>
        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> toRemove)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            toRemove
                .Recover()
                .ForEach(x => collection.Remove(x));
        }

        /// <summary>
        /// Removes items from collection based on given predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection to remove elements from</param>
        /// <param name="predicate">The predicate if item needs to be removed</param>
        public static void RemoveBy<T>(this ICollection<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection.Recover().ToArray())
            {
                if (predicate(item))
                    collection.Remove(item);
            }
        }
    }
}
