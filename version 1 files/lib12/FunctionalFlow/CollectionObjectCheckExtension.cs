using System.Collections.Generic;
using System.Linq;
using lib12.Misc;

namespace lib12.FunctionalFlow
{
    public static class CollectionObjectCheckExtension
    {
        /// <summary>
        /// Packs given object into array.
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static TSource[] PackIntoArray<TSource>(this TSource source)
        {
            return source != null ? new[] { source } : Empty.Array<TSource>();
        }

        /// <summary>
        /// Packs given object into array.
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static List<TSource> PackIntoList<TSource>(this TSource source)
        {
            return source != null ? new List<TSource> { source } : Empty.List<TSource>();
        }

        /// <summary>
        /// Checks if given collection contains this object
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static bool In<TSource>(this TSource source, IEnumerable<TSource> collection)
        {
            return collection.Contains(source);
        }

        /// <summary>
        /// Checks if given collection does not contains this object
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static bool NotIn<TSource>(this TSource source, IEnumerable<TSource> collection)
        {
            return !collection.Contains(source);
        }
    }
}