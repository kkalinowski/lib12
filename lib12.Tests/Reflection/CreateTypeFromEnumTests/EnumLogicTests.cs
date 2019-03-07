using System;
using lib12.Reflection;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection.CreateTypeFromEnumTests
{
    public sealed class EnumLogicTests
    {
        public enum SampleEnum
        {
            [CreateType(typeof(object))]
            CreateSimplestObject,
            NotDecoratedWithCreateTypeAttribute
        }

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

        [Fact]
        public void GetAttribute_from_enum_value_is_correct()
        {
            SampleEnum.CreateSimplestObject
                .GetAttribute<CreateTypeAttribute>()
                .ShouldNotBeNull();

            SampleEnum.NotDecoratedWithCreateTypeAttribute
                .GetAttribute<CreateTypeAttribute>()
                .ShouldBeNull();
        }

        [Fact]
        public void IsMarkedWithAttribute_from_enum_value_is_correct()
        {
            SampleEnum.CreateSimplestObject
                .IsMarkedWithAttribute<CreateTypeAttribute>()
                .ShouldBeTrue();

            SampleEnum.NotDecoratedWithCreateTypeAttribute
                .IsMarkedWithAttribute<CreateTypeAttribute>()
                .ShouldBeFalse();
        }
    }
}
