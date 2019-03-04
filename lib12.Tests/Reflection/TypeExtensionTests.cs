using System;
using System.Collections;
using lib12.Reflection;
using lib12.Utility;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection
{
    public class TypeExtensionTests
    {
        private static class StaticClass { }
        private class NonStaticClass { }

        private class EmptyType { }

        private class TypeWithCtorAndProps
        {
            public int Number { get; set; }
            public string Text { get; set; }

            public TypeWithCtorAndProps(int number, string text)
            {
                Number = number;
                Text = text;
            }
        }

        private class TypeWithoutParameterlessConstructor
        {
            public TypeWithoutParameterlessConstructor(int a)
            {

            }
        }

        private class TypeWithConst
        {
            public const string Text = "string_const";
            private const string PrivateText = "private_string_const";
        }

        private interface IEmptyInterface
        {

        }

        private class TypeImplementingInterface : IEmptyInterface
        {

        }

        private interface IGenericInterface<T>
        {
            T Property { get; set; }
        }

        private class TypeImplementingGenericInterface : IGenericInterface<int>
        {
            public int Property { get; set; }
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

        [Fact]
        public void GetConstants_is_correct()
        {
            typeof(TypeWithConst).GetConstants().Length.ShouldBe(2);
        }

        [Fact]
        public void GetConstants_throws_exception_if_given_null()
        {
            Assert.Throws<ArgumentNullException>(() => ((Type)null).GetConstants());
        }

        [Fact]
        public void GetConstantValues_is_correct()
        {
            var dict = typeof(TypeWithConst).GetConstantValues();

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
            dict["Text"].ShouldBe("string_const");
            dict["PrivateText"].ShouldBe("private_string_const");
        }

        [Fact]
        public void GetConstantValueByName_is_correct()
        {
            typeof(TypeWithConst)
                .GetConstantValueByName("PrivateText")
                .ShouldBe("private_string_const");
        }

        [Fact]
        public void GetConstantValueByName_throws_exception_if_cannot_find_constant()
        {
            Assert.Throws<lib12Exception>(() => typeof(TypeWithConst).GetConstantValueByName("not_existing_constant"));
        }

        [Fact]
        public void GetAttribute_is_correct()
        {
            var attribute = typeof(TypeWithParameterAttribute).GetAttribute<AttributeWithIntParameter>();

            attribute.ShouldNotBeNull();
            attribute.Parameter.ShouldBe(20);
        }

        [Fact]
        public void IsMarkedWithAttribute_is_correct()
        {
            typeof(TypeWithoutAttributes)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeFalse();

            typeof(TypeWithParameterlessAttribute)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeTrue();
        }

        [Fact]
        public void CreateInstance_is_correct_for_type_without_constructor()
        {
            typeof(EmptyType)
                .CreateInstance<EmptyType>()
                .ShouldNotBeNull();
        }

        [Fact]
        public void CreateInstance_is_correct_for_type_without_default_constructor()
        {
            const int number = 12;
            const string text = "test_text";

            var result = typeof(TypeWithCtorAndProps)
                .CreateInstance<TypeWithCtorAndProps>(number, text);

            result.ShouldNotBeNull();
            result.Number.ShouldBe(number);
            result.Text.ShouldBe(text);
        }

        [Fact]
        public void CreateInstance_throws_exception_on_types_mismatch()
        {
            Assert.Throws<lib12Exception>(() => typeof(EmptyType).CreateInstance<TypeWithCtorAndProps>());
        }

        [Fact]
        public void CreateInstance_throws_exception_on_ctor_mismatch()
        {
            Assert.Throws<MissingMethodException>(() => typeof(TypeWithCtorAndProps).CreateInstance<TypeWithCtorAndProps>(12));
        }

        [Fact]
        public void IsImplementingInterface_throws_exception_when_passing_the_same_type()
        {
            Assert.Throws<lib12Exception>(() => typeof(IEnumerable).IsImplementingInterface<IEnumerable>());
        }

        [Fact]
        public void IsImplementingInterface_throws_exception_when_target_type_is_not_interface()
        {
            Assert.Throws<lib12Exception>(() => typeof(IEnumerable).IsImplementingInterface<object>());
        }

        [Fact]
        public void IsImplementingInterface_is_correct()
        {
            typeof(EmptyType).IsImplementingInterface<IEnumerable>().ShouldBeFalse();
            typeof(TypeImplementingInterface).IsImplementingInterface<IEmptyInterface>().ShouldBeTrue();
        }

        [Fact]
        public void IsImplementingInterface_is_correct_for_generic_interface()
        {
            typeof(EmptyType).IsImplementingInterface<IGenericInterface<int>>().ShouldBeFalse();
            typeof(TypeImplementingGenericInterface).IsImplementingInterface<IGenericInterface<string>>().ShouldBeFalse();
            typeof(TypeImplementingGenericInterface).IsImplementingInterface<IGenericInterface<int>>().ShouldBeTrue();
        }

        [Fact]
        public void IsImplementingInterface_is_correct_for_explicit_type()
        {
            typeof(EmptyType).IsImplementingInterface(typeof(IEnumerable)).ShouldBeFalse();
            typeof(TypeImplementingInterface).IsImplementingInterface(typeof(IEmptyInterface)).ShouldBeTrue();
        }

        [Fact]
        public void IsImplementingInterface_is_correct_for_generic_interface_and_explicit_type()
        {
            typeof(EmptyType).IsImplementingInterface(typeof(IGenericInterface<>)).ShouldBeFalse();
            typeof(EmptyType).IsImplementingInterface(typeof(IGenericInterface<int>)).ShouldBeFalse();

            typeof(TypeImplementingGenericInterface).IsImplementingInterface(typeof(IGenericInterface<>)).ShouldBeTrue();
            typeof(TypeImplementingGenericInterface).IsImplementingInterface(typeof(IGenericInterface<string>)).ShouldBeFalse();
            typeof(TypeImplementingGenericInterface).IsImplementingInterface(typeof(IGenericInterface<int>)).ShouldBeTrue();
        }
    }
}