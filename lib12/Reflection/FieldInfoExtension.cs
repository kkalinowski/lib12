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
        public static T GetAttribute<T>(this FieldInfo field) where T : Attribute
        {
            var attribute = field.GetCustomAttributes(typeof(T), false).SingleOrDefault();
            return attribute != null ? (T)attribute : default(T);
        }
    }
}
