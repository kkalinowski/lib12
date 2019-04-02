using System;
using System.Linq;
using System.Reflection;

namespace lib12.Reflection
{
    /// <summary>
    /// ReflectionObjectExtension
    /// </summary>
    public static class ReflectionObjectExtension
    {
        /// <summary>
        /// Sets value of given property by name
        /// </summary>
        /// <param name="object">The target object</param>
        /// <param name="propertyName">Name of the property to set</param>
        /// <param name="value">The value to set</param>
        /// <exception cref="lib12Exception">Given object doesn't have property " + propertyName</exception>
        [Obsolete("Use Type.SetPropertyValueByName")]
        public static void SetProperty(this object @object, string propertyName, object value)
        {
            var prop = @object.GetType().GetTypeInfo().DeclaredProperties.FirstOrDefault(x => x.Name == propertyName);
            if (prop == null)
                throw new lib12Exception("Given object doesn't have property " + propertyName);

            prop.SetValue(@object, value, null);
        }
    }
}