using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton, WireUpAllProperties]
    class WireUpAllPropertiesWithWireUpAttribute
    {
        public TransientClass Wired { get; set; }
        [WireUp]
        public TransientClass AlsoWired { get; set; }
    }
}
