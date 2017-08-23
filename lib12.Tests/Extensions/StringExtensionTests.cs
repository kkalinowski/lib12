using lib12.Extensions;
using Shouldly;
using Xunit;

namespace lib12.Test.Extensions
{
    public class StringExtensionTests
    {
        [Fact]
        public void recover_null_returns_empty_string()
        {
            ((string)null).Recover().ShouldBe(string.Empty);
        }

        [Fact]
        public void recover_non_empty_string_returns_same_string()
        {
            const string test = "Test string";
            test.Recover().ShouldBe(test);
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