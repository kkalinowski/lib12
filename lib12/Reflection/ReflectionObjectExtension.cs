using System.Linq;
using lib12.Exceptions;
using lib12.Extensions;

namespace lib12.Reflection
{
    public static class ReflectionObjectExtension
    {
        public static void SetProperty(this object @object, string propertyName, object value)
        {
            var prop = @object.GetType().GetProperties().FirstOrDefault(x => x.Name == propertyName);
            prop.ThrowExceptionIfNull(new lib12Exception("Given object doesn't have property " + propertyName));

            prop.SetValue(@object, value, null);
        }
    }
}