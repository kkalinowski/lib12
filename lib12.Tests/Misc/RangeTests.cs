using System;
using lib12.Misc;
using Shouldly;
using Xunit;

namespace lib12.Test.Misc
{
    public class RangeTests
    {
        [Fact]
        public void in_range_int()
        {
            var range = new Range<int>(3, 12);
            range.InRange(5).ShouldBeTrue();
            range.InRange(2).ShouldBeFalse();
            range.InRange(3).ShouldBeTrue();
            range.InRange(3, false).ShouldBeFalse();
        }

        [Fact]
        public void in_range_double()
        {
            var range = new Range<double>(3.5, 12.8);
            range.InRange(5.7).ShouldBeTrue();
            range.InRange(500.35).ShouldBeFalse();
            range.InRange(12.8).ShouldBeTrue();
            range.InRange(12.8, false).ShouldBeFalse();
        }

        [Fact]
        public void in_range_datetime()
        {
            var range = new Range<DateTime>(new DateTime(1980, 3, 12, 13, 45, 20), new DateTime(2010, 5, 23, 5, 34, 17));
            range.InRange(new DateTime(2005, 7, 12)).ShouldBeTrue();
            range.InRange(new DateTime(2018, 10, 2)).ShouldBeFalse();
            range.InRange(new DateTime(1980, 3, 12, 13, 45, 20)).ShouldBeTrue();
            range.InRange(new DateTime(1980, 3, 12, 13, 45, 20), false).ShouldBeFalse();
        }

        [Fact]
        public void outside_of_range_int()
        {
            var range = new Range<int>(3, 12);
            range.OutsideOfRange(5).ShouldBeFalse();
            range.OutsideOfRange(2).ShouldBeTrue();
            range.OutsideOfRange(3).ShouldBeFalse();
            range.OutsideOfRange(3, false).ShouldBeTrue();
        }

        [Fact]
        public void less_than_start_int()
        {
            var range = new Range<int>(30, 45);
            range.LessThanStart(5).ShouldBeTrue();
            range.LessThanStart(34).ShouldBeFalse();
            range.LessThanStart(30).ShouldBeFalse();
        }

        [Fact]
        public void greater_than_end_int()
        {
            var range = new Range<int>(30, 45);
            range.GreaterThanEnd(5).ShouldBeFalse();
            range.GreaterThanEnd(45).ShouldBeFalse();
            range.GreaterThanEnd(50).ShouldBeTrue();
        }

        [Fact]
        public void locate_in_range_int()
        {
            var range = new Range<int>(3, 12);
            range.LocateInRange(2).ShouldBe(LocationInRange.LessThanStart);
            range.LocateInRange(3).ShouldBe(LocationInRange.OnStart);
            range.LocateInRange(5).ShouldBe(LocationInRange.InRange);
            range.LocateInRange(12).ShouldBe(LocationInRange.OnEnd);
            range.LocateInRange(15).ShouldBe(LocationInRange.GreaterThanEnd);
        }

        [Fact]
        public void reverse_ctor_in_range_int()
        {
            var range = new Range<int>(12, 3);
            range.InRange(5).ShouldBeTrue();
            range.InRange(2).ShouldBeFalse();
            range.InRange(3).ShouldBeTrue();
            range.InRange(3, false).ShouldBeFalse();
        }

        [Fact]
        public void same_value_int()
        {
            var range = new Range<int>(12, 12);
            range.InRange(5).ShouldBeFalse();
            range.InRange(2).ShouldBeFalse();
            range.InRange(12).ShouldBeTrue();
            range.InRange(12, false).ShouldBeFalse();
        }
    }
}