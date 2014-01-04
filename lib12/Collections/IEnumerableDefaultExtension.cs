using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib12.Collections
{
    public static class IEnumerableDefaultExtension
    {
        #region AverageOrDefault
        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else zero</returns>
        public static double AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, int> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : 0;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else null</returns>
        public static double? AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, int?> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : null;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else zero</returns>
        public static double AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, long> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : 0;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else null</returns>
        public static double? AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, long?> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : null;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else zero</returns>
        public static float AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, float> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : 0f;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else null</returns>
        public static float? AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, float?> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : null;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else zero</returns>
        public static double AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, double> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : 0;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else null</returns>
        public static double? AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, double?> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : null;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else zero</returns>
        public static decimal AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, decimal> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : 0m;
        }

        /// <summary>
        /// Computes average, returns default value if collection is empty
        /// </summary>
        /// <param name="enumerable">The enumerable to get items</param>
        /// <param name="selector">The selector to get values</param>
        /// <returns>Average if enumerable is not empty, else null</returns>
        public static decimal? AverageOrDefault<T>(this IEnumerable<T> enumerable, Func<T, decimal?> selector)
        {
            return enumerable.IsNotEmpty() ? enumerable.Average(selector) : null;
        } 
        #endregion

        #region SumOrDefault

        #endregion
    }
}
