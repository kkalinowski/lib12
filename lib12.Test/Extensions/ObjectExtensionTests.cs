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