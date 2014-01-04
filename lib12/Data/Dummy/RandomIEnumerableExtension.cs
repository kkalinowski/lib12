using System;
using System.Collections.Generic;
using System.Linq;
using lib12.Collections;

namespace lib12.Data.Dummy
{
    public static class RandomIEnumerableExtension
    {
        #region Fields
        private static Random random;
        #endregion

        #region sctor
        static RandomIEnumerableExtension()
        {
            random = new Random();
        }
        #endregion

        #region Logic
        public static T GetRandomItem<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable.IsEmpty())
                return default(T);

            return enumerable.ElementAt(random.Next(enumerable.Count()));
        } 
        #endregion
    }
}
