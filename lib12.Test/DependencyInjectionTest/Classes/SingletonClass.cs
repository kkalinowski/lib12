using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton]
    public class SingletonClass
    {
        public const int IntPropValue = 12;
        public int IntProp { get; set; }

        public SingletonClass()
        {
            IntProp = IntPropValue;
        }
    }
}
