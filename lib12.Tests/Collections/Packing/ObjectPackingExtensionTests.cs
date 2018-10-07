using System;
using lib12.Collections.Packing;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections.Packing
{
    public class ObjectPackingExtensionTests
    {
        [Fact]
        public void PackIntoArray_is_correct_for_value_type()
        {
            var result = 12.PackIntoArray();

            result.Length.ShouldBe(1);
            result[0].ShouldBe(12);
        }

        [Fact]
        public void PackIntoArray_is_correct_for_reference_type()
        {
            var toPack = new object();
            var result = toPack.PackIntoArray();

            result.Length.ShouldBe(1);
            result[0].ShouldBe(toPack);
        }
    }
}