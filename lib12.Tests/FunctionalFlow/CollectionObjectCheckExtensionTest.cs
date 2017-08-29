using lib12.FunctionalFlow;
using Shouldly;
using Xunit;

namespace lib12.Tests.FunctionalFlow
{
    public class CollectionObjectCheckExtensionTest
    {
        [Fact]
        public void in_test()
        {
            var array = new[] { 3, 4, 12 };
            12.In(array).ShouldBeTrue();
        }

        [Fact]
        public void not_in_test()
        {
            var array = new[] { 3, 4, 12 };
            11.NotIn(array).ShouldBeTrue();
        }

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
    }
}