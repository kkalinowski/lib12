using System;
using System.Collections.Generic;

namespace lib12.Utility
{
    /// <summary>
    /// Compares two objects for equality based on single property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyOrderComparer<T> : IComparer<T> where T : class
    {
        private readonly Func<T, object> _keyExtractor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyOrderComparer{T}"/> class.
        /// </summary>
        /// <param name="keyExtractor">The key extractor.</param>
        public PropertyOrderComparer(Func<T, object> keyExtractor)
        {
            _keyExtractor = keyExtractor;
        }

        /// <inheritdoc />
        public int Compare(T x, T y)
        {
            return Comparer<T>.Default.Compare(x, y);
        }
    }
}