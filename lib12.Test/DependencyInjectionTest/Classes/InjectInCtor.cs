using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton]
    public class InjectInCtor
    {
        public SingletonClass Prop1 { get; private set; }

        public InjectInCtor(SingletonClass prop1)
        {
            Prop1 = prop1;
        }
    }
}