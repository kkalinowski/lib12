using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
{
    public class DictionaryExtensionTests
    {
        [Fact]
        public void GetValueOrDefault_of_string_dictionary_is_correct()
        {
            var dict = new Dictionary<int, string>
            {
                {1, "first"},
                {2, "second"},
                {3, "third"}
            };

            dict.GetValueOrDefault(1).ShouldBe("first");
            dict.GetValueOrDefault(4).ShouldBeNull();
            dict.GetValueOrDefault(5, "five").ShouldBe("five");
        }

        [Fact]
        public void GetValueOrDefault_of_int_dictionary_is_correct()
        {
            var dict = new Dictionary<int, int>
            {
                {1, 10},
                {2, 20},
                {3, 30}
            };

            dict.GetValueOrDefault(1).ShouldBe(10);
            dict.GetValueOrDefault(4).ShouldBe(0);
            dict.GetValueOrDefault(5, -1).ShouldBe(-1);
        }
    }
}