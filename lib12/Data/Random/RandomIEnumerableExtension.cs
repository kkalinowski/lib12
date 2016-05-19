using System.Collections.Generic;
using System.Linq;
using lib12.Collections;

namespace lib12.Data.Random
{
    public static class RandomIEnumerableExtension
    {
        #region Fields
        private static readonly System.Random instanceRandom;
        #endregion

        #region sctor
        static RandomIEnumerableExtension()
        {
            instanceRandom = new System.Random();
        }
        #endregion

        #region Logic
        public static T GetRandomItem<T>(this IEnumerable<T> enumerable, System.Random random = null)
        {
            if (enumerable.IsNullOrEmpty())
                return default(T);

            var usedRandom = random ?? instanceRandom;
            return enumerable.ElementAt(usedRandom.Next(enumerable.Count()));
        }
        #endregion
    }
}
