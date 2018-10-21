using System;
using System.Linq;
using lib12.Collections.Packing;
using lib12.Utility.Comparing;
using Shouldly;
using Xunit;

namespace lib12.Tests.Utility.Comparing
{
    public class PropertyOrderComparerTests
    {
        private class CompareTarget
        {
            public int Value { get; set; }
            public CompareTarget Nested { get; set; }
        }

        [Fact]
        public void throws_exception_if_selector_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                PropertyOrderComparer.For<string>(null);
            });
        }

        [Fact]
        public void compare_two_string_by_length()
        {
            const string string1 = "lorem xyz";
            const string string2 = "ipsum";
            var comparer = PropertyOrderComparer.For<string>(x => x.Length);

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

            var comparer = PropertyOrderComparer.For<CompareTarget>(x => x.Nested);

            Assert.Throws<ArgumentException>(() => comparer.Compare(obj1, obj2));
        }

        [Fact]
        public void PropertyOrderComparer_can_be_used_to_order_collection()
        {
            var string1 = "winter is coming";
            var string2 = "abc";
            var string3 = "car-auto";
            var unordered = Pack.IntoArray(string1, string2, string3);
            
            var ordered = unordered
                .OrderBy(x => x, PropertyOrderComparer.For<string>(x => x.Length))
                .ToArray();

            ordered[0].ShouldBe(string2);
            ordered[1].ShouldBe(string3);
            ordered[2].ShouldBe(string1);
        }
    }
}