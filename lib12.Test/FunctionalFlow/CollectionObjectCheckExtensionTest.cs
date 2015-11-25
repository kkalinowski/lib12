using lib12.FunctionalFlow;
using Should;
using Xunit;

namespace lib12.Test.FunctionalFlow
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
    }
}