using System.Collections.Generic;
using System.Linq;
using lib12.Collections;

namespace lib12.Data.Random
{
    public static class RandomIEnumerableExtension
    {
        public static T GetRandomItem<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable.IsNullOrEmpty())
                return default(T);

            return enumerable.ElementAt(Rand.NextInt(enumerable.Count()));
        }
    }
}
