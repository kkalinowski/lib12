using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections
{
    /// <summary>
    /// ArrayExtension
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Flattens 2D array to one dimensional enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source array</param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this T[,] source)
        {
            if (source == null)
                yield break;

            foreach (var item in source)
                yield return item;
        }

        /// <summary>
        /// Flattens 2D jagged array to one dimensional enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source array</param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this T[][] source)
        {
            return source
                .Recover()
                .SelectMany(x => x);
        }

        /// <summary>
        /// Flattens 3D array to one dimensional enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source array</param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this T[,,] source)
        {
            if (source == null)
                yield break;

            foreach (var item in source)
                yield return item;
        }

        /// <summary>
        /// Flattens 2D jagged array to one dimensional enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source array</param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this T[][][] source)
        {
            return source
                .Recover()
                .SelectMany(x => x)
                .SelectMany(x => x);
        }
    }
}