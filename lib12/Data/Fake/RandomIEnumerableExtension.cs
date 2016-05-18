using System;
using System.Collections.Generic;
using System.Linq;
using lib12.Collections;

namespace lib12.Data.Dummy
{
    public static class RandomIEnumerableExtension
    {
        #region Fields
        private static readonly Random instanceRandom;
        #endregion

        #region sctor
        static RandomIEnumerableExtension()
        {
            instanceRandom = new Random();
        }
        #endregion

        #region Logic
        public static T GetRandomItem<T>(this IEnumerable<T> enumerable, Random random = null)
        {
            if (enumerable.IsNullOrEmpty())
                return default(T);

            var usedRandom = random ?? instanceRandom;
            return enumerable.ElementAt(usedRandom.Next(enumerable.Count()));
        }
        #endregion
    }
}
