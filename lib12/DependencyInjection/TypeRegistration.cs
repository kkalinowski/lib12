using System;

namespace lib12.DependencyInjection
{
    public class TypeRegistration
    {
        #region Props
        public Type Type { get; set; }
        public bool IsSingleton { get; set; }
        public bool WireUpAllProperties { get; set; }
        public Type WithService { get; set; }
        #endregion

        #region ctor
        public TypeRegistration()
        {
            
        }

        public TypeRegistration(Type type, bool isSingleton, bool wireUpAllProperties, Type withService)
        {
            Type = type;
            IsSingleton = isSingleton;
            WireUpAllProperties = wireUpAllProperties;
            WithService = withService;
        }
        #endregion
    }
}
