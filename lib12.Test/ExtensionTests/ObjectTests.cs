using lib12.Extensions;
using System;
using Should;
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
            Assert.Throws<NullReferenceException>(() => nullObject.ThrowExceptionIfNull());
        }

        [Fact]
        public void throw_given_exception_throws_exception_if_object_is_null()
        {
            var exceptionToThrow = new Exception("test_exception");
            try
            {
                nullObject.ThrowExceptionIfNull(exceptionToThrow);
            }
            catch (Exception exception)
            {
                exception.ShouldEqual(exceptionToThrow);
            }
        }

        [Fact]
        public void throw_exception_doesnt_throws_exception_if_object_is_not_null()
        {
            Assert.DoesNotThrow(() => notNullObject.ThrowExceptionIfNull());
        }

        [Fact]
        public void throw_given_exception_doesnt_throws_exception_if_object_is_not_null()
        {
            var exceptionToThrow = new Exception("test_exception");
            Assert.DoesNotThrow(() => notNullObject.ThrowExceptionIfNull(exceptionToThrow));
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
            notNullComplexObject.SafeGet(x => x.StringProp).ShouldEqual(StringPropValue);
        }

        [Fact]
        public void get_value_or_default_returns_default_if_object_is_null()
        {
            nullComplexObject.SafeGet(x => x.IntProp).ShouldEqual(default(int));
        }

        [Fact]
        public void get_value_or_default_returns_given_default_if_object_is_null()
        {
            const string defaultString = "default_string";
            nullComplexObject.SafeGet(x => x.StringProp, defaultString).ShouldEqual(defaultString);
        }

        [Fact]
        public void pack_into_array_test()
        {
            var @object = new object();
            @object.PackIntoArray().ShouldContain(@object);
        }

        [Fact]
        public void pack_into_list_test()
        {
            var @object = new object();
            @object.PackIntoList().ShouldContain(@object);
        }

        [Fact]
        public void in_test()
        {
            var array = new[] {3, 4, 12};
            12.In(array).ShouldBeTrue();
        }

        [Fact]
        public void not_in_test()
        {
            var array = new[] { 3, 4, 12 };
            11.NotIn(array).ShouldBeTrue();
        }
    }
}