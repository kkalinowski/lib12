using System;
using lib12.Utility;
using Shouldly;
using Xunit;

namespace lib12.Tests.Utility
{
    public class PropertyOrderComparerTests
    {
        private class CompareTarget
        {
            public int Value { get; set; }
            public CompareTarget Nested { get; set; }
        }

        [Fact]
        public void compare_two_string_by_length()
        {
            const string string1 = "lorem xyz";
            const string string2 = "ipsum";
            var comparer = new PropertyOrderComparer<string, int>(x => x.Length);

            comparer.Compare(string1, string2).ShouldBe(1);
        }

        [Fact]
        public void compare_two_objects_without_not_implementing_comparable_throws_exception()
        {
            var obj1 = new CompareTarget
            {
                Nested = new CompareTarget { Value = 3 }
            };
            var obj2 = new CompareTarget
            {
                Nested = new CompareTarget { Value = 12 }
            };

            var comparer = new PropertyOrderComparer<CompareTarget, CompareTarget>(x => x.Nested);

            Assert.Throws<ArgumentException>(() => comparer.Compare(obj1, obj2));
        }

        [Fact]
        public void compare_two_string_by_length_using_get_hash_code()
        {
            const string string1 = "lorem";
            const string string2 = "ipsum";
            var comparer = new PropertyEqualityComparer<string>(x => x.Length);

            Assert.Equal(comparer.GetHashCode(string1), comparer.GetHashCode(string2));
        }
    }
}