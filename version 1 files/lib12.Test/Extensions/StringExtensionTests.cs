using lib12.Extensions;
using Should;
using Xunit;

namespace lib12.Test.Extensions
{
    public class StringExtensionTests
    {
        [Fact]
        public void format_with_test()
        {
            "lib{0} is done by {1}".FormatWith(12, "me").ShouldEqual("lib12 is done by me");
        }

        [Fact]
        public void recover_null_returns_empty_string()
        {
            ((string)null).Recover().ShouldEqual(string.Empty);
        }

        [Fact]
        public void recover_non_empty_string_returns_same_string()
        {
            const string test = "Test string";
            test.Recover().ShouldEqual(test);
        }

        [Fact]
        public void equalsignorecase_two_equal_same_case_returns_true()
        {
            const string first = "Test string";
            const string second = "Test string";

            first.EqualsIgnoreCase(second).ShouldBeTrue();
        }

        [Fact]
        public void equalsignorecase_two_equal_different_case_returns_true()
        {
            const string first = "Test string";
            const string second = "tEst sTrinG";

            first.EqualsIgnoreCase(second).ShouldBeTrue();
        }

        [Fact]
        public void equalsignorecase_two_different_returns_false()
        {
            const string first = "Test string";
            const string second = "Different test string";

            first.EqualsIgnoreCase(second).ShouldBeFalse();
        }
    }
}