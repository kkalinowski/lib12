using System.Collections.Generic;
using lib12.Collections;
using lib12.Collections.Paging;
using lib12.Data.Random;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections.Paging
{
    public class PagingTests
    {
        [Fact]
        public void get_number_of_pages_returns_zero_for_null()
        {
            ((IEnumerable<int>)null).GetNumberOfPages(10).ShouldBe(0);
        }

        [Fact]
        public void get_number_of_pages_returns_zero_for_empty_collection()
        {
            Empty.Enumerable<int>().GetNumberOfPages(10).ShouldBe(0);
        }

        [Fact]
        public void get_number_of_pages_throws_exception_if_number_of_items_per_page_is_less_than_one()
        {
            var collection = CollectionFactory.CreateArray(10, x => Rand.NextInt());
            Assert.Throws<lib12Exception>(() => collection.GetNumberOfPages(0));
        }

        [Fact]
        public void get_number_of_pages_happy_path()
        {
            var collection = CollectionFactory.CreateArray(10, x => Rand.NextInt());
            collection.GetNumberOfPages(4).ShouldBe(3);
        }
    }
}