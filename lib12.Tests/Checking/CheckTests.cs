using lib12.Checking;
using Shouldly;
using Xunit;

namespace lib12.Tests.Checking
{
    public class CheckTests
    {
        [Fact]
        public void all_are_null_test()
        {
            Check.AllAreNull(null, null).ShouldBeTrue();
            Check.AllAreNull(new object(), null).ShouldBeFalse();
            Check.AllAreNull(new object(), new object()).ShouldBeFalse();
        }

        [Fact]
        public void all_are_not_null_test()
        {
            Check.AllAreNotNull(null, null).ShouldBeFalse();
            Check.AllAreNotNull(new object(), null).ShouldBeFalse();
            Check.AllAreNotNull(new object(), new object()).ShouldBeTrue();
        }

        [Fact]
        public void any_is_null_test()
        {
            Check.AnyIsNull(null, null).ShouldBeTrue();
            Check.AnyIsNull(new object(), null).ShouldBeTrue();
            Check.AnyIsNull(new object(), new object()).ShouldBeFalse();
        }

        [Fact]
        public void any_is_not_null_test()
        {
            Check.AnyIsNotNull(null, null).ShouldBeFalse();
            Check.AnyIsNotNull(new object(), null).ShouldBeTrue();
            Check.AnyIsNotNull(new object(), new object()).ShouldBeTrue();
        }
    }
}