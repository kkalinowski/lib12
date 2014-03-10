using System;
using System.Collections.Generic;

namespace lib12.Core
{
    /// <summary>
    /// Compares two objects based on property value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyComparer<T> : IEqualityComparer<T> where T : class 
    {
        private readonly Func<T, object> keyExtractor;

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