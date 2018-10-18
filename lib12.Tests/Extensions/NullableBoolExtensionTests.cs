using lib12.Extensions;
using Shouldly;
using Xunit;

namespace lib12.Tests.Extensions
{
    public class NullableBoolExtensionTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void IsTrue_is_correct(bool? source, bool expectedResult)
        {
            source.IsTrue().ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void IsFalse_is_correct(bool? source, bool expectedResult)
        {
            source.IsFalse().ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void IsNullOrFalse_is_correct(bool? source, bool expectedResult)
        {
            source.IsNullOrFalse().ShouldBe(expectedResult);
        }
    }
}