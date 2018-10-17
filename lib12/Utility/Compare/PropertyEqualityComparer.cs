using System;
using System.Collections.Generic;

namespace lib12.Utility.Compare
{
    /// <summary>
    /// Compares two objects for equality based on single property value
    /// </summary>
    public static class PropertyEqualityComparer
    {
        /// <summary>
        /// Creates comparer for given type and its property
        /// </summary>
        /// <typeparam name="TSource">The source type</typeparam>
        /// <param name="selector">The selector for property to compare</param>
        /// <returns></returns>
        public static IEqualityComparer<TSource> For<TSource>(Func<TSource, object> selector)
            where TSource : class
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return new PropertyEqualityComparerImplementation<TSource>(selector);
        }
    }

    /// <summary>
    /// Compares two objects for equality based on single property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class PropertyEqualityComparerImplementation<T> : IEqualityComparer<T> where T : class
    {
        private readonly Func<T, object> _keyExtractor;

        public PropertyEqualityComparerImplementation(Func<T, object> keyExtractor)
        {
            _keyExtractor = keyExtractor;
        }

        public bool Equals(T x, T y)
        {
            return _keyExtractor(x).Equals(_keyExtractor(y));
        }

        public int GetHashCode(T obj)
        {
            return _keyExtractor(obj).GetHashCode();
        }
    }
}