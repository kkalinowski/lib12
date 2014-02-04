using FluentAssertions;
using lib12.Extensions;
using System;
using Xunit;

namespace lib12.Test.ExtensionTests
{
    public class ObjectTests
    {
        private const string nullObject = null;
        private const string notNullObject = "test_string";
        private const string StringPropValue = "test_string_prop";
        private readonly NullCheck notNullComplexObject = new NullCheck { StringProp = StringPropValue };
        private readonly NullCheck nullComplexObject = null;

        private class NullCheck
        {
            public string StringProp { get; set; }
            public int IntProp { get; set; }
        }

        [Fact]
        public void null_returns_true_if_object_is_null()
        {
            Assert.True(nullObject.Null());
        }

        [Fact]
        public void null_returns_false_if_object_is_not_null()
        {
            Assert.False(notNullObject.Null());
        }

        [Fact]
        public void throw_exception_throws_exception_if_object_is_null()
        {
            nullObject.Invoking(x => x.Null().ThrowException()).ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void throw_exception_doesnt_throws_exception_if_object_is_not_null()
        {
            notNullObject.Invoking(x => x.Null().ThrowException()).ShouldNotThrow<NullReferenceException>();
        }

        [Fact]
        public void not_null_returns_false_if_object_is_null()
        {
            Assert.False(nullObject.NotNull());
        }

        [Fact]
        public void not_null_returns_true_if_object_is_not_null()
        {
            Assert.True(notNullObject.NotNull());
        }

        [Fact]
        public void get_value_or_default_returns_value_if_object_is_not_null()
        {
            notNullComplexObject.NotNull().Get(x => x.StringProp).Should().Be(StringPropValue);
        }

        [Fact]
        public void get_value_or_default_returns_default_if_object_is_null()
        {
            var result = nullComplexObject.NotNull().Get(x => x.IntProp).Should().Be(default(int));
        }

        [Fact]
        public void get_value_or_default_returns_given_default_if_object_is_null()
        {
            const string defaultString = "default_string";
            nullComplexObject.NotNull().Get(x => x.StringProp, defaultString).Should().Be(defaultString);
        }
    }
}