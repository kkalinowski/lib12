using System;

namespace lib12.DependencyInjection
{
    public class NotRegisteredTypeException : DependencyInjectionException
    {
        #region Props
        public Type Type { get; set; } 
        #endregion

        #region ctor
        public NotRegisteredTypeException(Type type)
            : base(string.Format("Type {0} is not registered", type.FullName))
        {
            Type = type;
        } 
        #endregion
    }
}
