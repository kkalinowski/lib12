using lib12.Reflection;

namespace lib12.Test.EnumLogicTests
{
    public enum SampleEnum
    {
        [CreateType(typeof(object))]
        CreateSimplestObject,
        NotDecoratedWithCreateTypeAttribute
    }
}
