using System.Collections.Generic;

namespace lib12.Collections.Packing
{
    /// <summary>
    /// ObjectPackingExtension
    /// </summary>
    public static class ObjectPackingExtension
    {
        /// <summary>
        /// Packs given object into array
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static TSource[] PackIntoArray<TSource>(this TSource source)
        {
            return source != null ? new[] { source } : Empty.Array<TSource>();
        }

        /// <summary>
        /// Packs given object into list
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static List<TSource> PackIntoList<TSource>(this TSource source)
        {
            return source != null ? new List<TSource> { source } : Empty.List<TSource>();
        }

        /// <summary>
        /// Packs given object into enumerable
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> PackIntoEnumerable<TSource>(this TSource source)
        {
            if (source != null)
                yield return source;
        }
    }
}