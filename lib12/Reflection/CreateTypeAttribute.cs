using System;

namespace lib12.Reflection
{
    /// <summary>
    /// Describes which type is associated with enum
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CreateTypeAttribute : Attribute
    {
        #region Props
        public Type Type { get; set; } 
        #endregion

        #region ctor
        public CreateTypeAttribute(Type type)
        {
            Type = type;
        }
        #endregion
    }
}
