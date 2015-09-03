using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjection.Classes
{
    [Singleton, WireUpAllProperties]
    class CircularCtorDependency2
    {
        private CircularCtorDependency1 circularCtorDependency1;

        public CircularCtorDependency2(CircularCtorDependency1 circularCtorDependency1)
        {
            this.circularCtorDependency1 = circularCtorDependency1;
        }
    }
}
