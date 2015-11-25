using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjection.Classes
{
    [Singleton, WireUpAllProperties]
    class CircularCtorDependency1
    {
        private CircularCtorDependency2 circularCtorDependency2;

        public CircularCtorDependency1(CircularCtorDependency2 circularCtorDependency2)
        {
            this.circularCtorDependency2 = circularCtorDependency2;
        }
    }
}
