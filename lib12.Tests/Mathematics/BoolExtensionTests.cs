using lib12.Mathematics.Extensions;
using Shouldly;
using Xunit;

namespace lib12.Tests.Mathematics
{
    public class BoolExtensionTests
    {
        [Fact]
        public void to_int_returns_1_if_source_is_true()
        {
            true.ToInt().ShouldBe(1);
        }

        [Fact]
        public void to_int_returns_0_if_source_is_false()
        {
            false.ToInt().ShouldBe(0);
        }
    }
}