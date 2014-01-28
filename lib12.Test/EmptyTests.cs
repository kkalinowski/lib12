using FluentAssertions;
using lib12.Core;
using Xunit;

namespace lib12.Test
{
    public sealed class EmptyTests
    {
        [Fact]
        public void empty_array_returns_empty_array()
        {
            var array = Empty.Array<int>();

            array.Should().NotBeNull().And.BeEmpty();
        }
    }
}