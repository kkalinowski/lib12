using lib12.Collections;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
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

        [Fact]
        public void empty_read_only_collection_returns_empty_read_only_collection()
        {
            var collection = Empty.ReadOnlyCollection<int>();
            collection.ShouldNotBeNull();
            collection.ShouldBeEmpty();
        }

        [Fact]
        public void empty_read_only_dictionary_returns_empty_read_only_dictionary()
        {
            var dictionary = Empty.ReadOnlyDictionary<int, string>();
            dictionary.ShouldNotBeNull();
            dictionary.ShouldBeEmpty();
        }
    }
}