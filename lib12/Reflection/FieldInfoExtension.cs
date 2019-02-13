using System;
using System.Linq;
using System.Reflection;

namespace lib12.Reflection
{
    /// <summary>
    /// FieldInfoExtension
    /// </summary>
    public static class FieldInfoExtension
    {
        /// <summary>
        /// Gets the attribute decorating given field
        /// </summary>
        /// <param name="field">The field to check</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MemberInfo field) where T : Attribute
        {
            var attribute = field.GetCustomAttributes(typeof(T), false).SingleOrDefault();
            return (T)attribute;
        }

        /// <summary>
        /// Checks if field is marked with given attribute
        /// </summary>
        /// <param name="field">The field to check</param>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <returns></returns>
        public static bool IsMarkedWithAttribute<T>(this MemberInfo field) where T : Attribute
        {
            return Attribute.IsDefined(field, typeof(T));
        }
    }
}
