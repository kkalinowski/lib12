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

        [Fact]
        public void empty_dictionary_returns_empty_dictionary()
        {
            Empty.Dictionary<int, string>().ShouldNotBeNull().ShouldBeEmpty();
        }

        [Fact]
        public void empty_enumerable_returns_empty_enumerable()
        {
            Empty.Enumerable<int>().ShouldNotBeNull().ShouldBeEmpty();
        }
    }
}