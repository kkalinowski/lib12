using System;
using System.Linq;
using System.Reflection;

namespace lib12.Reflection
{
    /// <summary>
    /// EnumReflectionExtension
    /// </summary>
    public static class EnumReflectionExtension
    {
        /// <summary>
        /// Gets the attribute decorating given enum value
        /// </summary>
        /// <param name="enumValue">The enum value to check</param>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValue.ToString());
            var attribute = fieldInfo.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            return (T)attribute;
        }

        /// <summary>
        /// Checks if enum value is marked with given attribute
        /// </summary>
        /// <param name="enumValue">The enum value to check</param>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <returns></returns>
        public static bool IsMarkedWithAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValue.ToString());
            return Attribute.IsDefined(fieldInfo, typeof(T));
        }
    }
}
