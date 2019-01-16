using lib12.Collections;
using lib12.Collections.Packing;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
{
    public class ArrayExtensionTests
    {
        [Fact]
        public void Flatten_2DArray_is_correct()
        {
            var array = new[,] { { 1, 2 }, { 3, 4 } };

            array
                .Flatten()
                .ShouldBe(Pack.IntoEnumerable(1, 2, 3, 4));
        }

        [Fact]
        public void Flatten_null_2DArray_returns_empty_collection()
        {
            ((int[,])null)
                .Flatten()
                .ShouldBeEmpty();
        }

        [Fact]
        public void Flatten_jagged_2DArray_is_correct()
        {
            var array = new int[2][];
            array[0] = new[] { 1, 2 };
            array[1] = new[] { 3, 4 };

            array
                .Flatten()
                .ShouldBe(Pack.IntoEnumerable(1, 2, 3, 4));
        }

        [Fact]
        public void Flatten_jagged_null_2DArray_returns_empty_collection()
        {
            ((int[][])null)
                .Flatten()
                .ShouldBeEmpty();
        }

        [Fact]
        public void Flatten_3DArray_is_correct()
        {
            var array = new[,,] { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };

            array
                .Flatten()
                .ShouldBe(Pack.IntoEnumerable(1, 2, 3, 4, 5, 6, 7, 8));
        }

        [Fact]
        public void Flatten_null_3DArray_returns_empty_collection()
        {
            ((int[,,])null)
                .Flatten()
                .ShouldBeEmpty();
        }

        [Fact]
        public void Flatten_jagged_3DArray_is_correct()
        {
            var array = new int[2][][];
            array[0] = new int[2][];
            array[0][0] = new[] { 1, 2 };
            array[0][1] = new[] { 3, 4 };
            array[1] = new int[2][];
            array[1][0] = new[] { 5, 6 };
            array[1][1] = new[] { 7, 8 };

            array
                .Flatten()
                .ShouldBe(Pack.IntoEnumerable(1, 2, 3, 4, 5, 6, 7, 8));
        }

        [Fact]
        public void Flatten_jagged_null_3DArray_returns_empty_collection()
        {
            ((int[][][])null)
                .Flatten()
                .ShouldBeEmpty();
        }
    }
}