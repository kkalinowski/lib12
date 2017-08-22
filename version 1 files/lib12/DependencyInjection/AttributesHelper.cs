using System;
using System.Linq;

namespace lib12.DependencyInjection
{
    internal static class AttributesHelper
    {
        public static TypeDecoration GetTypeDecoration(Type type)
        {
            var attributes = type.GetCustomAttributes(false).Select(x => x.GetType()).ToArray();
            return new TypeDecoration
            {
                IsSingleton = attributes.Any(x => x == typeof(SingletonAttribute)),
                IsTransient = attributes.Any(x => x == typeof(TransientAttribute)),
                WireUpAllProperties = attributes.Any(x => x == typeof(WireUpAllPropertiesAttribute))
            };
        }
    }
}
