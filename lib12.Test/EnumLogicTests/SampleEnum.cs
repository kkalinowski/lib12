using lib12.Enums;

namespace lib12.Test.EnumLogicTests
{
    public enum SampleEnum
    {
        [CreateType(typeof(object))]
        CreateSimplestObject,
        NotDecoratedWithCreateTypeAttribute
    }
}
