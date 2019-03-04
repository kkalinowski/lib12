using System;
using System.Collections;
using lib12.Reflection;
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

        private class TypeWithFields
        {
            private int _number;
            public int Number => _number;

            public string _text;

            public TypeWithFields(int number, string text)
            {
                _number = number;
                _text = text;
            }
        }

        private class ComplexType
        {
            public const int Const = 20;
            private int _number;
            public string Text { get; set; }

            public ComplexType(int number, string text)
            {
                _number = number;
                Text = text;
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

        [Fact]
        public void GetPropertyByName_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new TypeWithCtorAndProps(number, text);
            var type = obj.GetType();

            type
                .GetPropertyValueByName(obj, nameof(TypeWithCtorAndProps.Number))
                .ShouldBe(number);

            type
                .GetPropertyValueByName(obj, nameof(TypeWithCtorAndProps.Text))
                .ShouldBe(text);
        }

        [Fact]
        public void GetPropertiesValues_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new TypeWithCtorAndProps(number, text);
            var type = obj.GetType();

            var props = type.GetPropertiesValues(obj);
            props.Count.ShouldBe(2);
            props[nameof(TypeWithCtorAndProps.Number)].ShouldBe(number);
            props[nameof(TypeWithCtorAndProps.Text)].ShouldBe(text);
        }

        [Fact]
        public void SetPropertyByName_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new TypeWithCtorAndProps(number, text);
            var type = obj.GetType();

            type.SetPropertyValueByName(obj, nameof(TypeWithCtorAndProps.Number), number * 2);
            type.SetPropertyValueByName(obj, nameof(TypeWithCtorAndProps.Text), text + text);

            obj.Number.ShouldBe(24);
            obj.Text.ShouldBe("test_texttest_text");
        }

        [Fact]
        public void GetFieldByName_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new TypeWithFields(number, text);
            var type = obj.GetType();

            type
                .GetFieldValueByName(obj, "_number")
                .ShouldBe(number);
            type
                .GetFieldValueByName(obj, "_text")
                .ShouldBe(text);
        }

        [Fact]
        public void GetFieldByName_cant_get_constant_value()
        {
            var obj = new TypeWithConst();
            var type = obj.GetType();

            Assert.Throws<lib12Exception>(() => type.GetFieldValueByName(obj, nameof(TypeWithConst.Text)));
        }

        [Fact]
        public void SetFieldByName_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new TypeWithFields(number, text);
            var type = obj.GetType();

            type.SetFieldValueByName(obj, "_number", number * 2);
            type.SetFieldValueByName(obj, "_text", text + text);

            obj.Number.ShouldBe(24);
            obj._text.ShouldBe("test_texttest_text");
        }

        [Fact]
        public void SetFieldByName_cant_set_constant_value()
        {
            var obj = new TypeWithConst();
            var type = obj.GetType();

            Assert.Throws<lib12Exception>(() => type.SetFieldValueByName(obj, nameof(TypeWithConst.Text), "test"));
        }

        [Fact]
        public void GetFieldsValues_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new TypeWithFields(number, text);
            var type = obj.GetType();

            var fields = type.GetFieldsValues(obj);
            fields.Count.ShouldBe(2);
            fields["_number"].ShouldBe(number);
            fields["_text"].ShouldBe(text);
        }

        [Fact]
        public void GetAllObjectData_is_correct()
        {
            const int number = 12;
            const string text = "test_text";
            var obj = new ComplexType(number, text);
            var type = obj.GetType();

            var data = type.GetAllObjectData(obj);
            data.Count.ShouldBe(3);
            data["Const"].ShouldBe(ComplexType.Const);
            data["_number"].ShouldBe(number);
            data["Text"].ShouldBe(text);
        }
    }
}