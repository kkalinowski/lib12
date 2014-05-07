using System;
using System.Linq;

namespace lib12.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Determines whether given enum equals another
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enum">First enum</param>
        /// <param name="value">Second enum</param>
        /// <returns></returns>
        public static bool Is<TEnum>(this TEnum @enum, TEnum value)
        {
            return @enum.Equals(value);
        }

        /// <summary>
        /// Determines whether given enum is in given enum collection
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enum">First enum</param>
        /// <param name="values">Enum collection to check</param>
        /// <returns></returns>
        public static bool Is<TEnum>(this TEnum @enum, params TEnum[] values)
        {
            return values.Any(x => @enum.Equals(x));
        }

        /// <summary>
        /// Determines whether given enum does not equals another
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enum">First enum</param>
        /// <param name="value">Second enum</param>
        /// <returns></returns>
        public static bool IsNot<TEnum>(this TEnum @enum, TEnum value)
        {
            return !@enum.Equals(value);
        }

        /// <summary>
        /// Determines whether given enum is not in given enum collection
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="enum">First enum</param>
        /// <param name="values">Enum collection to check</param>
        /// <returns></returns>
        public static bool IsNot<TEnum>(this TEnum @enum, params TEnum[] values)
        {
            return values.All(x => !@enum.Equals(x));
        }

    }
}