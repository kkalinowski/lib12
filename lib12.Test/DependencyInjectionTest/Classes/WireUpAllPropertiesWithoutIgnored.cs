using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton, WireUpAllProperties]
    class WireUpAllPropertiesWithoutIgnored
    {
        public TransientClass Wired { get; set; }
        [DoNotWireUp]
        public NotRegisteredClass NotWired { get; set; }
    }
}
