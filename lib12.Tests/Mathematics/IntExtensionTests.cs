using lib12.Mathematics.Extensions;
using Shouldly;
using Xunit;

namespace lib12.Tests.Mathematics
{
    public class IntExtensionTests
    {
        [Fact]
        public void to_bool_returns_false_if_given_zero()
        {
            0.ToBool().ShouldBeFalse();
        }

        [Fact]
        public void to_bool_returns_true_if_given_non_zero()
        {
            12.ToBool().ShouldBeTrue();
        }
    }
}