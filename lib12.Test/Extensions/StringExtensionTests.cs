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
            "lib{0} is done by {1}".FormatWith(12,"me").ShouldEqual("lib12 is done by me");
        }
    }
}