using System;
using lib12.Exceptions;
using lib12.Reflection;
using Xunit;

namespace lib12.Test.ReflectionTests.CreateTypeFromEnumTests
{
    public sealed class EnumLogicTests
    {
        [Fact]
        public void create_type_attribute_test()
        {
            var created = SampleEnum.CreateSimplestObject.CreateType<object>();
            Assert.NotNull(created);
        }

        [Fact]
        public void throw_exception_when_creating_type_from_undecorated_enum()
        {
            Assert.Throws<lib12Exception>(() => SampleEnum.NotDecoratedWithCreateTypeAttribute.CreateType<object>());
        }

        [Fact]
        public void throw_exception_when_creating_wrong_type_from_enum()
        {
            Assert.Throws<InvalidCastException>(() => SampleEnum.CreateSimplestObject.CreateType<string>());
        }
    }
}
