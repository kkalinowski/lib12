using System;
using lib12.Collections;
using lib12.Collections.Packing;
using lib12.Data.Random;
using Shouldly;
using Xunit;

namespace lib12.Tests.Data.Random
{
    public class RandomIEnumerableExtensionTests
    {
        [Fact]
        public void GetRandomItem_returns_element_from_given_collection()
        {
            var array = Pack.IntoArray(23, 45, 12);

            var result = array.GetRandomItem();

            array.ShouldContain(result);
        }

        [Fact]
        public void GetRandomItem_returns_only_element_if_collection_has_one_element()
        {
            const int item = 23;

            var result = item.PackIntoArray().GetRandomItem();

            result.ShouldBe(item);
        }

        [Fact]
        public void GetRandomItem_throws_exception_if_collection_is_null()
        {
            string[] nullArray = null;

            Assert.Throws<ArgumentException>(()=> nullArray.GetRandomItem());
        }

        [Fact]
        public void GetRandomItem_throws_exception_if_collection_is_empty()
        {
            Assert.Throws<ArgumentException>(() => Empty.Array<string>().GetRandomItem());
        }
    }
}