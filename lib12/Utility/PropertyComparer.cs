using System;
using System.Collections.Generic;

namespace lib12.Utility
{
    /// <summary>
    /// Compares two objects based on property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Obsolete("Use PropertyEqualityComparer instead")]
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

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(T x, T y)
        {
            return keyExtractor(x).Equals(keyExtractor(y));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(T obj)
        {
            return keyExtractor(obj).GetHashCode();
        }
    }
}