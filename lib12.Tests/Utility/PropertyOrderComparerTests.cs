using lib12.Utility;
using Xunit;

namespace lib12.Tests.Utility
{
    public class PropertyOrderComparerTests
    {
        [Fact]
        public void compare_two_string_by_length()
        {
            const string string1 = "lorem";
            const string string2 = "ipsum";
            var comparer = PropertyOrderComparer<string, int>.For<string>(x => x.Length);

            //Assert.True(comparer.Equals(string1, string2));
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