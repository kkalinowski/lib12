using System;
using System.Collections.Generic;

namespace lib12.Utility
{
    /// <summary>
    /// Compares two objects for order based on single property value
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class PropertyOrderComparer<TSource> : IComparer<TSource> where TSource : class
    {
        private readonly Func<TSource, object> _selector;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyOrderComparer{TSource}"/> class.
        /// </summary>
        /// <param name="selector">The key extractor.</param>
        public PropertyOrderComparer(Func<TSource, object> selector)
        {
            _selector = selector;
        }

        /// <summary>
        /// Creates order comparer for given type using selector
        /// </summary>
        /// <typeparam name="TSource">Type of object to compare</typeparam>
        /// <param name="selector">Selector of value to compare</param>
        /// <returns></returns>
        public static PropertyOrderComparer<TSource> For<TSource>(Func<TSource, object> selector) where TSource : class
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return new PropertyOrderComparer<TSource>(selector);
        }

        /// <inheritdoc />
        public int Compare(TSource x, TSource y)
        {
            return Comparer<object>.Default.Compare(_selector(x), _selector(y));
        }
    }

    public class Factory
    {
        public static IComparer<TSource> For<TSource>(Func<TSource, object> selector)
            where TSource : class
        {
            return new PropertyOrderComparer<TSource>(selector);
        }
    }
}