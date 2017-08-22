using System.Linq;

namespace lib12.FunctionalFlow
{
    public static class ParamsObjectCheckExtension
    {
        public static bool AllNull(params object[] toCheck)
        {
            return toCheck.All(x => x.Null());
        }

        public static bool AllNotNull(params object[] toCheck)
        {
            return toCheck.All(x => x.NotNull());
        }

        public static bool AnyNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.Null());
        }

        public static bool AnyNotNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.NotNull());
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
    }
}