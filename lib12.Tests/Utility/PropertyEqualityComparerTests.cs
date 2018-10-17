using System;
using lib12.Utility;
using lib12.Utility.Compare;
using Shouldly;
using Xunit;

namespace lib12.Tests.Utility
{
    public class PropertyEqualityComparerTests
    {
        [Fact]
        public void throws_exception_if_selector_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                PropertyEqualityComparer.For<string>(null);
            });
        }

        [Fact]
        public void compare_two_string_by_length_using_equals()
        {
            const string string1 = "lorem";
            const string string2 = "ipsum";
            var comparer = PropertyEqualityComparer.For<string>(x => x.Length);

            comparer.Equals(string1, string2).ShouldBeTrue();
        }

        [Fact]
        public void compare_two_string_by_length_using_get_hash_code()
        {
            const string string1 = "lorem";
            const string string2 = "ipsum";
            var comparer = PropertyEqualityComparer.For<string>(x => x.Length);

            comparer.GetHashCode(string1)
                .ShouldBe(comparer.GetHashCode(string2));
        }
    }
}