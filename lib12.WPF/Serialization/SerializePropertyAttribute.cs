using System;

namespace lib12.WPF.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SerializePropertyAttribute : Attribute
    {
        #region Props
        public object DefaultValue { get; set; }
        public bool CreateNewAsDefaultValue { get; set; }
        #endregion

        #region ctor
        public SerializePropertyAttribute()
        {
        }

        public SerializePropertyAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
        #endregion
    }
}
