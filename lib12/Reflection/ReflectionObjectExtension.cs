using System.Linq;
using System.Reflection;
using lib12.Extensions;

namespace lib12.Reflection
{
    public static class ReflectionObjectExtension
    {
        public static void SetProperty(this object @object, string propertyName, object value)
        {
            var prop = @object.GetType().GetTypeInfo().DeclaredProperties.FirstOrDefault(x => x.Name == propertyName);
            if (prop.IsNull())
                throw new lib12Exception("Given object doesn't have property " + propertyName);

            prop.SetValue(@object, value, null);
        }
    }
}