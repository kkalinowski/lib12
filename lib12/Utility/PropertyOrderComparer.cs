using System;
using System.Collections.Generic;

namespace lib12.Utility
{
    /// <summary>
    /// Compares two objects for order based on single property value
    /// </summary>
    public static class PropertyOrderComparer
    {
        /// <summary>
        /// Creates comparer for given type and its property
        /// </summary>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <param name="selector">The selector for property to compare</param>
        /// <returns></returns>
        public static IComparer<TSource> For<TSource>(Func<TSource, object> selector)
            where TSource : class
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return new PropertyOrderComparerImplementation<TSource>(selector);
        }
    }

    internal class PropertyOrderComparerImplementation<TSource> : IComparer<TSource> where TSource : class
    {
        private readonly Func<TSource, object> _selector;

        public PropertyOrderComparerImplementation(Func<TSource, object> selector)
        {
            _selector = selector;
        }

        public int Compare(TSource x, TSource y)
        {
            return Comparer<object>.Default.Compare(_selector(x), _selector(y));
        }
    }
}