using System;
using lib12.Extensions;
using Should;
using Xunit;

namespace lib12.Test.Extensions
{
    public class ObjectExtensionTests
    {
        private const string nullObject = null;
        private const string notNullObject = "test_string";

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
    }
}