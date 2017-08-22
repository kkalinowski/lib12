using System.Reflection;

namespace lib12.DependencyInjection
{
    internal sealed class LazyProperty
    {
        #region Props
        public object Instance { get; set; }
        public PropertyInfo Property { get; set; }
        #endregion

        #region ctor
        public LazyProperty(object instance, PropertyInfo property)
        {
            Instance = instance;
            Property = property;
        }
        #endregion
    }
}
