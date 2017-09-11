using lib12.Collections;
using lib12.Utility;
using Shouldly;
using Xunit;

namespace lib12.Tests.Utility
{
    public sealed class EmptyTests
    {
        [Fact]
        public void empty_array_returns_empty_array()
        {
            var array = Empty.Array<int>();

            array.ShouldNotBeNull();
           array.ShouldBeEmpty();
        }

        [Fact]
        public void empty_list_returns_empty_list()
        {
            var list = Empty.List<int>();
            list.ShouldNotBeNull();
                list.ShouldBeEmpty();
        }

        [Fact]
        public void empty_dictionary_returns_empty_dictionary()
        {
            var dictionary = Empty.Dictionary<int, string>();
            dictionary.ShouldNotBeNull();
            dictionary.ShouldBeEmpty();
        }

        [Fact]
        public void empty_enumerable_returns_empty_enumerable()
        {
            var enumerable = Empty.Enumerable<int>();
            enumerable.ShouldNotBeNull();
            enumerable.ShouldBeEmpty();
        }
    }
}