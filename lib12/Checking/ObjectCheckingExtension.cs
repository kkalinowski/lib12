using System.Collections.Generic;
using System.Linq;

namespace lib12.Checking
{
    public static class ObjectCheckingExtension
    {
        /// <summary>
        /// Determines whether given source equals another
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">First source</param>
        /// <param name="value">Second source</param>
        /// <returns></returns>
        public static bool Is<TSource>(this TSource source, TSource value)
        {
            return Equals(source, value);
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
            return values.Any(x => Equals(source, x));
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
            return !Equals(source, value);
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
            return values.All(x => !Equals(source, x));
        }

        /// <summary>
        /// Checks if given collection contains this object
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static bool In<TSource>(this TSource source, IEnumerable<TSource> collection)
        {
            if (collection == null)
                return false;

            return collection.Contains(source);
        }

        /// <summary>
        /// Checks if given collection does not contains this object
        /// </summary>
        /// <typeparam name="TSource">The type of the object.</typeparam>
        /// <returns></returns>
        public static bool NotIn<TSource>(this TSource source, IEnumerable<TSource> collection)
        {
            if (collection == null)
                return true;

            return !collection.Contains(source);
        }
    }
}