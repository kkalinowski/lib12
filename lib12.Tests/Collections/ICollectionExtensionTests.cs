using System;
using System.Collections.Generic;
using lib12.Collections;
using lib12.Collections.Packing;
using Shouldly;
using Xunit;

namespace lib12.Tests.Collections
{
    public class ICollectionExtensionTests
    {
        [Fact]
        public void AddRange_throws_null_on_null_collection()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ((ICollection<int>)null).AddRange(Pack.IntoEnumerable(2, 3, 4));
            });
        }

        [Fact]
        public void AddRange_works_for_empty_collection()
        {
            var toAdd = Pack.IntoArray(4, 23, 12);
            ICollection<int> collection = Empty.List<int>();

            collection.AddRange(toAdd);

            collection.SequenceContentEqual(toAdd).ShouldBeTrue();
        }

        [Fact]
        public void AddRange_works_for_non_empty_collection()
        {
            var toAdd = Pack.IntoArray(4, 23, 12);
            ICollection<int> collection = Pack.IntoList(34, 5);

            collection.AddRange(toAdd);

            collection.SequenceContentEqual(Pack.IntoEnumerable(34, 5, 4, 23, 12)).ShouldBeTrue();
        }

        [Fact]
        public void RemoveRange_throws_null_on_null_collection()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ((ICollection<int>)null).RemoveRange(Pack.IntoEnumerable(2, 3, 4));
            });
        }

        [Fact]
        public void RemoveRange_dont_remove_anything_when_null_collection_is_given_to_remove()
        {
            ICollection<int> collection = Pack.IntoList(34, 5);

            collection.RemoveRange(null);

            collection.SequenceContentEqual(Pack.IntoEnumerable(34, 5)).ShouldBeTrue();
        }

        [Fact]
        public void RemoveRange_removes_only_elements_present_in_collection()
        {
            ICollection<int> collection = Pack.IntoList(34, 5);

            collection.RemoveRange(Pack.IntoEnumerable(12, 34));

            collection.SequenceContentEqual(Pack.IntoEnumerable(5)).ShouldBeTrue();
        }

        [Fact]
        public void RemoveBy_throws_null_on_null_collection()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ((ICollection<int>)null).RemoveBy(x => x < 0);
            });
        }

        [Fact]
        public void RemoveBy_throws_null_on_null_predicate()
        {
            ICollection<int> collection = Pack.IntoList(34, 5);

            Assert.Throws<ArgumentNullException>(() =>
            {
                collection.RemoveBy(null);
            });
        }

        [Fact]
        public void RemoveBy_is_correct_for_valid_arguments()
        {
            ICollection<int> collection = Pack.IntoList(34, 5);

            collection.RemoveBy(x => x > 12);

            collection.SequenceContentEqual(Pack.IntoEnumerable(5)).ShouldBeTrue();
        }
    }
}