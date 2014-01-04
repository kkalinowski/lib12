using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton]
    class DoNotWirePropertyWithDoNotWireAttributeAndWithoutWireUpAllProperties
    {
        [DoNotWireUp]
        public NotRegisteredClass NotWired { get; set; }
    }
}
