using lib12.Reflection;

namespace lib12.Tests.Reflection.CreateTypeFromEnumTests
{
    public enum SampleEnum
    {
        [CreateType(typeof(object))]
        CreateSimplestObject,
        NotDecoratedWithCreateTypeAttribute
    }
}
