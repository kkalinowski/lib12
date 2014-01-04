using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Singleton]
    class SingletonClassThatChangeProperty
    {
        public int IntProp { get; set; }

        public SingletonClassThatChangeProperty()
        {
            IntProp = SingletonClass.IntPropValue;
        }
    }
}
