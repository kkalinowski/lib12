using System.Collections.Generic;
using lib12.Checking;
using Shouldly;
using Xunit;

namespace lib12.Tests.Checking
{
    enum TestEnum
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }

    public class ObjectCheckingExtensionTests
    {
        [Fact]
        public void is_any_of_one_element_true()
        {
            var value = TestEnum.First;

            value.IsAnyOf(TestEnum.First).ShouldBeTrue();
        }

        [Fact]
        public void is_any_of_one_element_false()
        {
            var value = TestEnum.First;

            value.IsAnyOf(TestEnum.Second).ShouldBeFalse();
        }

        [Fact]
        public void is_any_of_collection_true()
        {
            var value = TestEnum.First;

            value.IsAnyOf(TestEnum.First, TestEnum.Second, TestEnum.Fifth).ShouldBeTrue();
        }

        [Fact]
        public void is_any_of_collection_false()
        {
            var value = TestEnum.First;

            value.IsAnyOf(TestEnum.Fourth, TestEnum.Second, TestEnum.Fifth).ShouldBeFalse();
        }

        [Fact]
        public void is_not_any_of_one_element_true()
        {
            var value = TestEnum.First;

            value.IsNotAnyOf(TestEnum.Second).ShouldBeTrue();
        }

        [Fact]
        public void is_not_any_of_one_element_false()
        {
            var value = TestEnum.First;

            value.IsNotAnyOf(TestEnum.First).ShouldBeFalse();
        }

        [Fact]
        public void is_not_any_of_collection_true()
        {
            var value = TestEnum.First;

            value.IsNotAnyOf(TestEnum.Third, TestEnum.Second, TestEnum.Fifth).ShouldBeTrue();
        }

        [Fact]
        public void is_not_any_of_collection_false()
        {
            var value = TestEnum.First;

            value.IsNotAnyOf(TestEnum.First, TestEnum.Second, TestEnum.Fifth).ShouldBeFalse();
        }

        [Fact]
        public void is_not_any_of_int_test()
        {
            4.IsNotAnyOf(5, 6, 6).ShouldBeTrue();
        }

        [Fact]
        public void is_any_of_string_test()
        {
            "test".IsAnyOf("test").ShouldBeTrue();
        }

        [Fact]
        public void is_any_of_handles_null_as_target_to_compare_test()
        {
            "test".IsAnyOf((string)null).ShouldBeFalse();
        }

        [Fact]
        public void is_any_of_handles_null_as_source_test()
        {
            ((string)null).IsAnyOf("test").ShouldBeFalse();
        }

        [Fact]
        public void is_any_of_returns_true_if_both_source_and_target_are_null_test()
        {
            ((string)null).IsAnyOf((string)null).ShouldBeTrue();
        }

        [Fact]
        public void is_any_of_collection_test()
        {
            var array = new[] { 3, 4, 12 };
            12.IsAnyOf(array).ShouldBeTrue();
        }

        [Fact]
        public void is_any_ofcollection_is_null_return_false_test()
        {
            12.IsAnyOf((IEnumerable<int>)null).ShouldBeFalse();
        }

        [Fact]
        public void is_not_any_of_collection_test()
        {
            var array = new[] { 3, 4, 12 };
            11.IsNotAnyOf(array).ShouldBeTrue();
        }

        [Fact]
        public void is_not_any_of_collection_is_null_return_true_test()
        {
            12.IsNotAnyOf((IEnumerable<int>)null).ShouldBeTrue();
        }
    }
}