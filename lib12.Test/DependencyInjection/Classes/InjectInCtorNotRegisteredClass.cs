using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjection.Classes
{
    [Singleton]
    class InjectInCtorNotRegisteredClass
    {
        public InjectInCtorNotRegisteredClass(NotRegisteredClass notRegisteredClass)
        {

        }
    }
}