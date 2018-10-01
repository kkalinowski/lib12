using System;
using System.Linq;
using lib12.Collections;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
{
    public class CollectionFactoryTests
    {
        [Fact]
        public void create_array_happy_path()
        {
            var result = CollectionFactory.CreateArray(3, i => i);
            result.Length.ShouldBe(3);
            result[0].ShouldBe(0);
            result[1].ShouldBe(1);
            result[2].ShouldBe(2);
        }

        [Fact]
        public void create_array_works_with_size_equal_to_zero()
        {
            var result = CollectionFactory.CreateArray(0, i => i);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void create_array_throws_exception_when_size_is_negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CollectionFactory.CreateArray(-1, i => i));
        }

        [Fact]
        public void create_array_throws_exception_when_create_function_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => CollectionFactory.CreateArray(12, (Func<int, int>)null));
        }
    }
}