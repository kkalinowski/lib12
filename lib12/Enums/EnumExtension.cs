using System;
using lib12.Exceptions;
using lib12.Extensions;

namespace lib12.Enums
{
    public static class EnumExtension
    {
        public static T CreateType<T>(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValue.ToString());
            var typeToCreate = fieldInfo.GetAttribute<CreateTypeAttribute>();
            if (typeToCreate == null)
                throw new lib12Exception("Given enum isn't decorated by CreateTypeAttribute");

            return (T)Activator.CreateInstance(typeToCreate.Type);
        }
    }
}
