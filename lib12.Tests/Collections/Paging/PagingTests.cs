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
        public void get_page_returns_correct_values_for_null_collection()
        {
            const int pageNumber = 1;
            const int itemsPerPage = 10;

            var result = ((IEnumerable<int>)null).GetPage(pageNumber, itemsPerPage);

            result.ItemsPerPage.ShouldBe(itemsPerPage);
            result.PageNumber.ShouldBe(pageNumber);
            result.TotalPages.ShouldBe(0);
            result.Items.ShouldBeEmpty();
        }

        [Fact]
        public void get_page_returns_correct_values_for_empty_collection()
        {
            const int pageNumber = 1;
            const int itemsPerPage = 10;

            var result = Empty.Enumerable<int>().GetPage(pageNumber, itemsPerPage);

            result.ItemsPerPage.ShouldBe(itemsPerPage);
            result.PageNumber.ShouldBe(pageNumber);
            result.TotalPages.ShouldBe(0);
            result.Items.ShouldBeEmpty();
        }

        [Fact]
        public void get_page_throws_exception_if_number_of_items_per_page_is_less_than_one()
        {
            var collection = CollectionFactory.CreateArray(10, x => Rand.NextInt());
            Assert.Throws<lib12Exception>(() => collection.GetPage(1, 0));
        }

        [Fact]
        public void get_page_throws_exception_if_number_of_page_is_less_than_one()
        {
            var collection = CollectionFactory.CreateArray(10, x => Rand.NextInt());
            Assert.Throws<lib12Exception>(() => collection.GetPage(0, 5));
        }

        [Fact]
        public void get_page_throws_exception_when_asking_for_page_higher_than_page_count()
        {
            var collection = CollectionFactory.CreateArray(10, x => Rand.NextInt());
            Assert.Throws<lib12Exception>(() => collection.GetPage(3, 5));
        }

        [Fact]
        public void get_page_returns_correct_first_page()
        {
            const int pageNumber = 1;
            const int itemsPerPage = 2;

            var collection = new[] { 23, 4, 5, 6, 98 };
            var result = collection.GetPage(pageNumber, itemsPerPage);

            result.ItemsPerPage.ShouldBe(itemsPerPage);
            result.PageNumber.ShouldBe(pageNumber);
            result.TotalPages.ShouldBe(3);
            result.Items.ShouldBe(new []{ 23, 4 });
        }

        [Fact]
        public void get_page_returns_correct_last_page()
        {
            const int pageNumber = 2;
            const int itemsPerPage = 2;

            var collection = new[] { 23, 4, 5, 98 };
            var result = collection.GetPage(pageNumber, itemsPerPage);

            result.ItemsPerPage.ShouldBe(itemsPerPage);
            result.PageNumber.ShouldBe(pageNumber);
            result.TotalPages.ShouldBe(2);
            result.Items.ShouldBe(new[] { 5, 98 });
        }

        [Fact]
        public void get_page_returns_correct_not_full_last_page()
        {
            const int pageNumber = 3;
            const int itemsPerPage = 2;

            var collection = new[] { 23, 4, 5, 6, 98 };
            var result = collection.GetPage(pageNumber, itemsPerPage);

            result.ItemsPerPage.ShouldBe(itemsPerPage);
            result.PageNumber.ShouldBe(pageNumber);
            result.TotalPages.ShouldBe(3);
            result.Items.ShouldBe(new[] { 98 });
        }

        [Fact]
        public void get_page_returns_correct_middle_page()
        {
            const int pageNumber = 2;
            const int itemsPerPage = 2;

            var collection = new[] { 23, 4, 5, 6, 98 };
            var result = collection.GetPage(pageNumber, itemsPerPage);

            result.ItemsPerPage.ShouldBe(itemsPerPage);
            result.PageNumber.ShouldBe(pageNumber);
            result.TotalPages.ShouldBe(3);
            result.Items.ShouldBe(new[] { 5, 6 });
        }
    }
}