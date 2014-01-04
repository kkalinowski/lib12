using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton, WireUpAllProperties]
    class WireAllPropertiesSingletonWithNotRegisteredProperties
    {
        public SingletonClass Prop1 { get; set; }
        public NotRegisteredClass Prop2 { get; set; }
    }
}
