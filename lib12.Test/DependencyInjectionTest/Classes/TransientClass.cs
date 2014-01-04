using lib12.DependencyInjection;

namespace lib12.Test.DependencyInjectionTest.Classes
{
    [Transient]
    class TransientClass
    {
        public int IntProp { get; set; }

        public TransientClass()
        {
            IntProp = 12;
        }
    }
}
