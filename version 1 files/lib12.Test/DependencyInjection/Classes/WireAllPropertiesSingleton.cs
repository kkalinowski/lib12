using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjection.Classes
{
    [Singleton, WireUpAllProperties]
    class WireAllPropertiesSingleton
    {
        public SingletonClass Prop1 { get; set; }
        public SingletonClass Prop2 { get; set; }
    }
}
