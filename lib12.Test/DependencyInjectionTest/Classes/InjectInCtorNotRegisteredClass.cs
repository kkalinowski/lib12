using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton]
    class InjectInCtorNotRegisteredClass
    {
        public InjectInCtorNotRegisteredClass(NotRegisteredClass notRegisteredClass)
        {

        }
    }
}