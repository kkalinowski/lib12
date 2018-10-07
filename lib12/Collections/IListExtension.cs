using System.Collections.Generic;

namespace lib12.Collections
{
    /// <summary>
    /// IListExtension
    /// </summary>
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
    }
}
