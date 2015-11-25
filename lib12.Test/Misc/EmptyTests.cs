using lib12.Misc;
using Should;
using Xunit;

namespace lib12.Test.Misc
{
    public sealed class EmptyTests
    {
        [Fact]
        public void empty_array_returns_empty_array()
        {
            var array = Empty.Array<int>();

            array.ShouldNotBeNull().ShouldBeEmpty();
        }

        [Fact]
        public void empty_list_returns_empty_list()
        {
            Empty.List<int>().ShouldNotBeNull().ShouldBeEmpty();
        }
    }
}