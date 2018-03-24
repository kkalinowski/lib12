using System.Linq;
using lib12.Collections.Packing;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
{
    public class ObjectPackingExtensionTests
    {
        [Fact]
        public void pack_into_array_test()
        {
            var source = new object();
            source.PackIntoArray().ShouldContain(source);
        }

        [Fact]
        public void pack_into_list_test()
        {
            var source = new object();
            source.PackIntoList().ShouldContain(source);
        }

        [Fact]
        public void pack_into_enumerable_returns_empty_enumerable_if_object_is_null()
        {
            object source = null;
            source.PackIntoEnumerable().ShouldBeEmpty();
        }

        [Fact]
        public void pack_into_enumerable_returns_enumerable_with_given_object()
        {
            var source = new object();

            var result = source.PackIntoEnumerable();

            result.Count().ShouldBe(1);
            result.First().ShouldBe(source);
        }
    }
}