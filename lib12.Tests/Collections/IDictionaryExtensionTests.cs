using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using lib12.Collections;

namespace lib12.Tests.Collections
{
    public class IDictionaryExtensionTests
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
            IDictionaryExtension.GetValueOrDefault(dict, 5, "five").ShouldBe("five");
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
            IDictionaryExtension.GetValueOrDefault(dict, 5, -1).ShouldBe(-1);
        }

        [Fact]
        public void ToReadOnlyDictionary_is_correct()
        {
            var dict = new Dictionary<int, string>
            {
                {1, "first"},
                {2, "second"},
                {3, "third"}
            };

            var readOnlyDict = dict.ToReadOnlyDictionary();
            readOnlyDict[1].ShouldBe("first");
            readOnlyDict[2].ShouldBe("second");
            readOnlyDict[3].ShouldBe("third");
        }

        [Fact]
        public void ToReadOnlyDictionary_returns_empty_dictionary_given_null()
        {
            ((Dictionary<int, string>)null).ToReadOnlyDictionary().ShouldBeEmpty();
        }

        [Fact]
        public void Recover_returns_empty_dictionary_given_null()
        {
            ((Dictionary<int, string>)null).Recover().ShouldBeEmpty();
        }

        [Fact]
        public void Recover_returns_same_dictionary_given_not_null()
        {
            var dict = new Dictionary<int, string>
            {
                {1, "first"},
                {2, "second"},
                {3, "third"}
            };

            dict.Recover().ShouldBe(dict);
        }

        [Fact]
        public void Concat_is_correct()
        {
            var dict = new Dictionary<int, string>
            {
                {1, "first"},
                {2, "second"},
                {3, "third"}
            };

            var secondDict = new Dictionary<int, string>
            {
                {4, "fourth"},
                {5, "fifth"}
            };

            var result = dict.Concat(secondDict);

            result.ShouldNotBeEmpty();
            result.Count.ShouldBe(5);
            result[3].ShouldBe("third");
            result[5].ShouldBe("fifth");
        }

        [Fact]
        public void Concat_works_for_nulls()
        {
            ((Dictionary<int, string>)null)
                .Concat((Dictionary<int, string>)null)
                .ShouldBeEmpty();
        }

        [Fact]
        public void Concat_throws_exception_when_encountering_duplicates()
        {
            var dict = new Dictionary<int, string>
            {
                {1, "first"},
            };

            var secondDict = new Dictionary<int, string>
            {
                {1, "first"},
            };

            Assert.Throws<ArgumentException>(() => dict.Concat(secondDict));
        }
    }
}