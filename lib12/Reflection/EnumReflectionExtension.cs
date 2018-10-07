using System;
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
            var type = enumValue.GetType();
            var fieldInfo = type.GetTypeInfo().GetDeclaredField(enumValue.ToString());
            var typeToCreate = fieldInfo.GetAttribute<CreateTypeAttribute>();
            if (typeToCreate == null)
                throw new lib12Exception("Given enum isn't decorated by CreateTypeAttribute");

            return (T)Activator.CreateInstance(typeToCreate.Type);
        }
    }
}
