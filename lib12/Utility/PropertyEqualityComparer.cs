using System;
using System.Collections.Generic;

namespace lib12.Utility
{
    /// <summary>
    /// Compares two objects for equality based on single property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyEqualityComparer<T> : IEqualityComparer<T> where T : class
    {
        private readonly Func<T, object> _keyExtractor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyComparer{T}"/> class.
        /// </summary>
        /// <param name="keyExtractor">The key extractor.</param>
        public PropertyEqualityComparer(Func<T, object> keyExtractor)
        {
            _keyExtractor = keyExtractor;
        }

        /// <inheritdoc />
        public bool Equals(T x, T y)
        {
            return _keyExtractor(x).Equals(_keyExtractor(y));
        }

        /// <inheritdoc />        
        public int GetHashCode(T obj)
        {
            return _keyExtractor(obj).GetHashCode();
        }
    }
}