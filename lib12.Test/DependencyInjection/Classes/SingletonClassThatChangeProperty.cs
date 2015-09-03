using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjection.Classes
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
