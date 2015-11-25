using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjection.Classes
{
    [Singleton, WireUpAllProperties]
    class CircularDependency1
    {
        public CircularDependency2 CircularDependency2 { get; set; }
    }
}
