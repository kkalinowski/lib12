using System;
using System.Collections.Generic;
using System.Linq;
using lib12.Collections;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
{
    public class IEnumerableExtensionTests
    {
        [Fact]
        public void formatting_collection_with_one_item()
        {
            const string expected = "test";
            var result = new[] { "test" }.ToDelimitedString("_");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void formatting_collection_with_two_item()
        {
            const string expected = "test_test2";
            var result = new[] { "test", "test2" }.ToDelimitedString("_");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void contains_one_element_returns_false_when_passing_null()
        {
            IEnumerable<int> enumerable = null;

            Assert.False(enumerable.ContainsOneElement());
        }

        [Fact]
        public void contains_one_element_returns_false_when_passing_empty_array()
        {
            var emptyArray = new int[0];

            Assert.False(emptyArray.ContainsOneElement());
        }

        [Fact]
        public void contains_one_element_returns_true_when_passing_enumerable_with_one_item()
        {
            var oneItemArray = new[] { 1 };

            Assert.True(oneItemArray.ContainsOneElement());
        }

        [Fact]
        public void contains_one_element_returns_false_when_passing_enumerable_with_two_items()
        {
            var twoItemsArray = new[] { 1, 2 };

            Assert.False(twoItemsArray.ContainsOneElement());
        }

        [Fact]
        public void recover_test_on_null_collection()
        {
            List<int> list = null;
            list.Recover().Count().ShouldBe(0);
        }

        [Fact]
        public void recover_on_not_null_collection()
        {
            var list = new List<int> { 3, 4, 12 };
            list.Recover().Count().ShouldBe(3);
        }

        [Fact]
        public void maxby_happy_path()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.MaxBy(x => x.Value).ShouldBe(list[2]);
        }

        [Fact]
        public void maxby_throws_argument_null_exception_if_enumerable_is_null()
        {
            List<Item> list = null;

            Assert.Throws<ArgumentNullException>(() => list.MaxBy(x => x.Value));
        }

        [Fact]
        public void maxby_throws_argument_null_exception_if_selector_is_null()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            Assert.Throws<ArgumentNullException>(() => list.MaxBy((Func<Item, int>)null));
        }

        [Fact]
        public void maxby_throws_invalid_operation_exception_if_collection_is_empty()
        {
            var list = new List<Item>();

            Assert.Throws<InvalidOperationException>(() => list.MaxBy(x => x.Value));
        }

        [Fact]
        public void minby_happy_path()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.MinBy(x => x.Value).ShouldBe(list[0]);
        }

        [Fact]
        public void minby_throws_argument_null_exception_if_enumerable_is_null()
        {
            List<Item> list = null;

            Assert.Throws<ArgumentNullException>(() => list.MinBy(x => x.Value));
        }

        [Fact]
        public void minby_throws_argument_null_exception_if_selector_is_null()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            Assert.Throws<ArgumentNullException>(() => list.MinBy((Func<Item, int>)null));
        }

        [Fact]
        public void minby_throws_invalid_operation_exception_if_collection_is_empty()
        {
            var list = new List<Item>();

            Assert.Throws<InvalidOperationException>(() => list.MinBy(x => x.Value));
        }

        [Fact]
        public void distinctby_happy_path()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 3 },
                new Item { Value = 12 } };

            var result = list.DistinctBy(x => x.Value);
            result.Count().ShouldBe(2);
            result.ElementAt(0).Value.ShouldBe(3);
            result.ElementAt(1).Value.ShouldBe(12);
        }

        [Fact]
        public void distinctby_throws_argument_null_exception_if_selector_is_null()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 3 },
                new Item { Value = 12 } };

            Assert.Throws<ArgumentNullException>(() => list.DistinctBy((Func<Item, int>)null).ToArray());
        }

        [Fact]
        public void distinctby_returns_empty_collection_if_enumerable_is_null()
        {
            List<Item> list = null;
            list.DistinctBy(x => x.Value).ShouldBeEmpty();
        }

        [Fact]
        public void distinctby_returns_empty_collectionn_if_enumerable_is_empty()
        {
            var list = new List<Item>();
            list.DistinctBy(x => x.Value).ShouldBeEmpty();
        }

        [Fact]
        public void findindex_happy_path()
        {
            var list = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.Select(x => x)
                .FindIndex(x => x.Value == 4)
                .ShouldBe(1);
        }

        [Fact]
        public void findindex_throws_argument_null_exception_if_selector_is_null()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            Assert.Throws<ArgumentNullException>(() => list.Select(x => x).FindIndex(null));
        }

        [Fact]
        public void findindex_finds_first_element()
        {
            var list = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.Select(x => x)
                .FindIndex(x => x.Value == 3)
                .ShouldBe(0);
        }

        [Fact]
        public void findindex_finds_last_element()
        {
            var list = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.Select(x => x)
                .FindIndex(x => x.Value == 12)
                .ShouldBe(2);
        }

        [Fact]
        public void findindex_returns_negative_one_if_cant_find_element()
        {
            var list = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.Select(x => x)
                .FindIndex(x => x.Value == 99)
                .ShouldBe(-1);
        }

        [Fact]
        public void findindex_returns_negative_one_if_collection_is_null()
        {
            IEnumerable<Item> list = null;

            list
                .FindIndex(x => x.Value == 12)
                .ShouldBe(-1);
        }

        [Fact]
        public void findindex_returns_negative_one_if_collection_is_empty()
        {
            var list = new List<Item>();

            list.Select(x => x)
                .FindIndex(x => x.Value == 12)
                .ShouldBe(-1);
        }

        [Fact]
        public void partition_happy_path()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            var result = list.Partition(x => x.Value < 6);
            result.True.Count.ShouldBe(2);
            result.False.Count.ShouldBe(1);
            result.True[0].ShouldBe(list[0]);
            result.True[1].ShouldBe(list[1]);
            result.False[0].ShouldBe(list[2]);
        }

        [Fact]
        public void partition_throws_argument_null_exception_if_selector_is_null()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 3 },
                new Item { Value = 12 } };

            Assert.Throws<ArgumentNullException>(() => list.Partition(null));
        }

        [Fact]
        public void partition_returns_empty_collection_if_enumerable_is_null()
        {
            List<Item> list = null;
            var result = list.Partition(x => x.Value < 6);

            result.True.ShouldBeEmpty();
            result.False.ShouldBeEmpty();
        }

        [Fact]
        public void partition_returns_empty_collectionn_if_enumerable_is_empty()
        {
            var list = new List<Item>();
            var result = list.Partition(x => x.Value < 6);

            result.True.ShouldBeEmpty();
            result.False.ShouldBeEmpty();
        }

        [Fact]
        public void batch_happy_path()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            var result = list.Batch(2);
            result.Count().ShouldBe(2);

            var batch1 = result.ElementAt(0);
            batch1.Length.ShouldBe(2);
            batch1[0].ShouldBe(list[0]);
            batch1[1].ShouldBe(list[1]);

            var batch2 = result.ElementAt(1);
            batch2.Length.ShouldBe(1);
            batch2[0].ShouldBe(list[2]);
        }

        [Fact]
        public void batch_throws_argument_out_of_range_if_size_is_equal_or_less_than_zero()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 3 },
                new Item { Value = 12 } };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Batch(0).ToArray());
        }

        [Fact]
        public void batch_returns_empty_collection_if_enumerable_is_null()
        {
            List<Item> list = null;
            var result = list.Batch(12);

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void batch_returns_empty_collectionn_if_enumerable_is_empty()
        {
            var list = new List<Item>();
            var result = list.Batch(12);

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void sequence_content_equals_on_two_same_collections_returns_true()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            var list2 = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            list.SequenceContentEqual(list2).ShouldBeTrue();
        }

        [Fact]
        public void sequence_content_equals_on_two_collections_with_same_content_but_different_order_true()
        {
            var list = new List<Item> {
                new Item{ Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };

            var list2 = new List<Item> {
                new Item{ Value = 12 },
                new Item { Value = 4 },
                new Item { Value = 3 } };

            list.SequenceContentEqual(list2).ShouldBeTrue();
        }

        [Fact]
        public void intersectby_happy_path()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            var result = list1.IntersectBy(list2, l1 => l1.Value, l2 => l2.Value).ToArray();
            result.Length.ShouldBe(2);
            result[0].Value.ShouldBe(4);
            result[1].Value.ShouldBe(12);
        }

        [Fact]
        public void intersectby_throws_exception_if_first_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.IntersectBy(list2, (Func<Item, int>)null, x => x.Value).ToArray());
        }

        [Fact]
        public void intersectby_throws_exception_if_second_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.IntersectBy(list2, x => x.Value, (Func<Item, int>)null).ToArray());
        }

        [Fact]
        public void exceptby_happy_path()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            var result = list1.ExceptBy(list2, l1 => l1.Value, l2 => l2.Value).ToArray();
            result.Length.ShouldBe(1);
            result[0].Value.ShouldBe(3);
        }

        [Fact]
        public void exceptby_throws_exception_if_first_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.ExceptBy(list2, (Func<Item, int>)null, x => x.Value).ToArray());
        }

        [Fact]
        public void exceptby_throws_exception_if_second_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.ExceptBy(list2, x => x.Value, (Func<Item, int>)null).ToArray());
        }

        [Fact]
        public void leftjoin_happy_path()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            var result = list1.LeftJoin(list2, l1 => l1.Value, l2 => l2.Value, (l1, l2) => (l1, l2)).ToArray();
            result.Length.ShouldBe(3);
            result[0].Item1.Value.ShouldBe(3);
            result[0].Item2.ShouldBeNull();
            result[1].Item1.Value.ShouldBe(4);
            result[1].Item2.Value.ShouldBe(4);
            result[2].Item1.Value.ShouldBe(12);
            result[2].Item2.Value.ShouldBe(12);
        }

        [Fact]
        public void leftjoin_throws_exception_if_first_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.LeftJoin(list2, (Func<Item, int>)null, y => y.Value, (x, y) => (x, y)).ToArray());
        }

        [Fact]
        public void leftjoin_throws_exception_if_second_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.LeftJoin(list2, x => x.Value, (Func<Item, int>)null, (x, y) => (x, y)).ToArray());
        }

        [Fact]
        public void leftjoin_throws_exception_if_result_selector_is_null()
        {
            var list1 = new List<Item> {
                new Item { Value = 3 },
                new Item { Value = 4 },
                new Item { Value = 12 } };
            var list2 = new List<Item> {
                new Item { Value = 4 },
                new Item { Value = 12 },
                new Item { Value = 20 } };

            Assert.Throws<ArgumentNullException>(() => list1.LeftJoin(list2, x => x.Value, y => y.Value, (Func<Item, Item, Tuple<Item, Item>>)null).ToArray());
        }

        [Fact]
        public void WithoutNulls_return_null_if_collection_is_null()
        {
            int[] collection = null;

            collection.WithoutNulls().ShouldBeNull();
        }

        [Fact]
        public void WithoutNulls_return_collection_without_nulls()
        {
            string[] collection = new[] { "test1", null, "test2", null };

            var result = collection.WithoutNulls().ToArray();
            result.Length.ShouldBe(2);
            result[0].ShouldBe("test1");
            result[1].ShouldBe("test2");
        }

        [Fact]
        public void ToReadOnlyCollection_is_correct()
        {
            var collection = new[] { "test1", "test2" };

            var result = collection.ToReadOnlyCollection();
            result.Count.ShouldBe(2);
            result[0].ShouldBe("test1");
        }

        [Fact]
        public void ToReadOnlyCollection_handles_null()
        {
            ((List<int>)null).ToReadOnlyCollection().ShouldBeEmpty();
        }

        [Fact]
        public void ToReadOnlyDictionary_is_correct()
        {
            var collection = new[] { "abc", "test" };

            var result = collection.ToReadOnlyDictionary(x => x.Length, x => x);
            result.Count.ShouldBe(2);
            result[3].ShouldBe("abc");
        }

        [Fact]
        public void ToReadOnlyDictionary_handles_null()
        {
            ((List<int>)null).ToReadOnlyDictionary(x => x, x => x).ShouldBeEmpty();
        }
    }
}
