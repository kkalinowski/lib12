using System;

namespace lib12.Reflection.CreationByEnum
{
    /// <summary>
    /// EnumReflectionExtension
    /// </summary>
    public static class CreateByEnumExtension
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
    }
}
