using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton, WireUpAllProperties]
    class CircularDependency2
    {
        public CircularDependency1 CircularDependency1 { get; set; }
    }
}
