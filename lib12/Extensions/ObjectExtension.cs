using System.Collections.Generic;
using System.Linq;
using lib12.Misc;

namespace lib12.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Check if given object is null
        /// </summary>
        /// <returns></returns>
        public static bool IsNull<TSource>(this TSource source) where TSource : class
        {
            return source == null;
        }

        ///// <summary>
        ///// Check if given object is not null
        ///// </summary>
        ///// <param name="source"></param>
        ///// <returns></returns>
        public static bool IsNotNull<TSource>(this TSource source) where TSource : class
        {
            return source != null;
        }

        /// <summary>
        /// Determines whether given source equals another
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">First source</param>
        /// <param name="value">Second source</param>
        /// <returns></returns>
        public static bool Is<TSource>(this TSource source, TSource value)
        {
            return source.Equals(value);
        }

        /// <summary>
        /// Determines whether given source is in given source collection
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">First source</param>
        /// <param name="values">source collection to check</param>
        /// <returns></returns>
        public static bool Is<TSource>(this TSource source, params TSource[] values)
        {
            return values.Any(x => source.Equals(x));
        }

        /// <summary>
        /// Determines whether given source does not equals another
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">First source</param>
        /// <param name="value">Second source</param>
        /// <returns></returns>
        public static bool IsNot<TSource>(this TSource source, TSource value)
        {
            return !source.Equals(value);
        }

        /// <summary>
        /// Determines whether given source is not in given source collection
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">First source</param>
        /// <param name="values">source collection to check</param>
        /// <returns></returns>
        public static bool IsNot<TSource>(this TSource source, params TSource[] values)
        {
            return values.All(x => !source.Equals(x));
        }

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