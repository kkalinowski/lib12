using System;
using System.Collections.Generic;

namespace lib12.Misc
{
    /// <summary>
    /// Compares two objects based on property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyComparer<T> : IEqualityComparer<T> where T : class 
    {
        private readonly Func<T, object> keyExtractor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyComparer{T}"/> class.
        /// </summary>
        /// <param name="keyExtractor">The key extractor.</param>
        public PropertyComparer(Func<T, object> keyExtractor)
        {
            this.keyExtractor = keyExtractor;
        }

        public bool Equals(T x, T y)
        {
            return keyExtractor(x).Equals(keyExtractor(y));
        }

        public int GetHashCode(T obj)
        {
            return keyExtractor(obj).GetHashCode();
        }
    }
}