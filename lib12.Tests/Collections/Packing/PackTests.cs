using lib12.Collections.Packing;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections.Packing
{
    public class PackTests
    {
        [Fact]
        public void PackIntoArray_is_correct_for_value_types()
        {
            var result = Pack.IntoArray(12, 100, 3);

            result.Length.ShouldBe(3);
            result[0].ShouldBe(12);
            result[1].ShouldBe(100);
            result[2].ShouldBe(3);
        }
    }
}