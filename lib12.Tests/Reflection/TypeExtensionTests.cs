using System;
using lib12.Reflection;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection
{
    public class TypeExtensionTests
    {
        private static class StaticClass { }
        private class NonStaticClass { }

        private class TypeWithoutParameterlessConstructor
        {
            public TypeWithoutParameterlessConstructor(int a)
            {

            }
        }

        [Fact]
        public void is_type_numeric_test()
        {
            Assert.True(typeof(int).IsTypeNumeric());
            Assert.True((-0.9).GetType().IsTypeNumeric());
            Assert.True(6.7m.GetType().IsTypeNumeric());
            Assert.False(typeof(string).IsTypeNumeric());
            Assert.False("string".GetType().IsTypeNumeric());
        }

        [Fact]
        public void is_nullable_test()
        {
            Assert.True(typeof(int?).IsNullable());
            Assert.True(typeof(decimal?).IsNullable());
            Assert.True(typeof(DateTime?).IsNullable());
            Assert.False(typeof(int).IsNullable());
            Assert.False(typeof(string).IsNullable());
        }

        [Fact]
        public void is_type_numeric_or_nullable_numeric_test()
        {
            Assert.True(typeof(int).IsTypeNumericOrNullableNumeric());
            Assert.True((-0.9).GetType().IsTypeNumericOrNullableNumeric());
            Assert.True(6.7m.GetType().IsTypeNumeric());
            Assert.False(typeof(string).IsTypeNumericOrNullableNumeric());
            Assert.False("string".GetType().IsTypeNumericOrNullableNumeric());

            Assert.True(typeof(int?).IsTypeNumericOrNullableNumeric());
            Assert.True(typeof(decimal?).IsTypeNumericOrNullableNumeric());
            Assert.False(typeof(DateTime?).IsTypeNumericOrNullableNumeric());
        }

        [Fact]
        public void get_default_constructor_of_type()
        {
            Assert.NotNull(typeof(object).GetDefaultConstructor());
        }

        [Fact]
        public void get_default_constructor_of_type_without_parameterless_ctor_returns_null()
        {
            Assert.Null(typeof(TypeWithoutParameterlessConstructor).GetDefaultConstructor());
        }

        [Fact]
        public void is_static_returns_true_for_static_class()
        {
            typeof(StaticClass).IsStatic().ShouldBeTrue();
        }

        [Fact]
        public void is_static_returns_false_for_non_static_class()
        {
            typeof(NonStaticClass).IsStatic().ShouldBeFalse();
        }
    }
}