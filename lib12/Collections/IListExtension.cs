using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections
{
    public static class IListExtension
    {
        /// <summary>
        /// Removes from collection elements from other collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to remove elements from</param>
        /// <param name="toRemove">Elements to remove</param>
        public static void RemoveRange<T>(this IList<T> list, IEnumerable<T> toRemove)
        {
            toRemove.ForEach(x => list.Remove(x));
        }


        /// <summary>
        /// Removes items by condition
        /// </summary>
        /// <param name="list">List of items</param>
        /// <param name="condition">Condition to remove item</param>
        public static void RemoveRange<T>(this IList<T> list, Predicate<T> condition)
        {
            foreach (var item in list.ToArray())
            {
                if (condition(item))
                    list.Remove(item);
            }
        }
    }
}
