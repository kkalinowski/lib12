using lib12.Reflection;

namespace lib12.Test.Reflection.CreateTypeFromEnumTests
{
    public enum SampleEnum
    {
        [CreateType(typeof(object))]
        CreateSimplestObject,
        NotDecoratedWithCreateTypeAttribute
    }
}
