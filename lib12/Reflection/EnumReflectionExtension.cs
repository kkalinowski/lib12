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
        /// Creates the type from given enum decorated with CreatedTypeAttribute
        /// </summary>
        /// <typeparam name="T">Created type</typeparam>
        /// <param name="enumValue">The enum value to create type from</param>
        /// <returns></returns>
        /// <exception cref="lib12Exception">Given enum isn't decorated by CreateTypeAttribute</exception>
        public static T CreateType<T>(this Enum enumValue)
        {
            var createTypeAttribute = enumValue.GetAttribute<CreateTypeAttribute>();
            if (createTypeAttribute == null)
                throw new lib12Exception("Given enum isn't decorated by CreateTypeAttribute");

            return (T)Activator.CreateInstance(createTypeAttribute.Type);
        }

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
