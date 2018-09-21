using System;

namespace lib12.Extensions
{
    public static class FuncExtension
    {
        /// <summary>
        /// Converts generic Func to non generic version, always returning object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source Func to convert</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static Func<object> ConvertToNonGeneric<T>(this Func<T> source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            return () => source();
        }
    }
}