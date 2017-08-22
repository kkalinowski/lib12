using System;
using System.Linq;
using System.Reflection;

namespace lib12.Reflection
{
    public static class FieldInfoExtension
    {
        /// <summary>
        /// Gets the attribute decorating given property
        /// </summary>
        /// <param name="propertyinfo">The property to check</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this FieldInfo field) where T : Attribute
        {
            var attribute = field.GetCustomAttributes(typeof(T), false).SingleOrDefault();
            return attribute != null ? (T)attribute : default(T);
        }
    }
}
