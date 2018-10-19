using System;
using lib12.Extensions;
using Shouldly;
using Xunit;

namespace lib12.Tests.Extensions
{
    public class DateTimeExtensionTests
    {
        [Fact]
        public void datetime_converts_properly_to_unix_timestamp()
        {
            var dateTime = new DateTime(2014, 01, 30, 12, 0, 0);

            dateTime.ToUnixTimeStamp().ShouldBe(1391083200);
        }

        [Fact]
        public void datetime_parses_properly_from_unix_timestamp()
        {
            const long toParse = 1391083200;
            DateTimeExtension.ParseUnixTimeStamp(toParse).ShouldBe(new DateTime(2014, 01, 30, 12, 0, 0, 0, DateTimeKind.Utc));
        }

        [Fact]
        public void isdefault_returns_true_on_datetime_created_with_default_keyword()
        {
            default(DateTime).IsDefault().ShouldBeTrue();
        }

        [Fact]
        public void isdefault_returns_true_on_datetime_created_with_default_parameterless_ctor()
        {
            new DateTime().IsDefault().ShouldBeTrue();
        }

        [Fact]
        public void isdefault_returns_false_on_datetime_with_non_default_date()
        {
            new DateTime(1900, 3, 25).IsDefault().ShouldBeFalse();
        }

        [Fact]
        public void AddWeeks_is_correct()
        {
            new DateTime(2018, 10, 19).AddWeeks(2).ShouldBe(new DateTime(2018, 11, 2));
            new DateTime(2018, 10, 16).AddWeeks(-1).ShouldBe(new DateTime(2018, 10, 9));
            new DateTime(2018, 10, 17).AddWeeks(0).ShouldBe(new DateTime(2018, 10, 17));
            new DateTime(2018, 10, 19).AddWeeks(1.5).ShouldBe(new DateTime(2018, 10, 29, 12, 0, 0));
        }

        [Fact]
        public void AddQuarters_is_correct()
        {
            new DateTime(2018, 10, 19).AddQuarters(2).ShouldBe(new DateTime(2019, 4, 19));
            new DateTime(2018, 10, 16).AddQuarters(-1).ShouldBe(new DateTime(2018, 7, 16));
            new DateTime(2018, 10, 17).AddQuarters(0).ShouldBe(new DateTime(2018, 10, 17));
        }

        [Fact]
        public void GetQuarter_is_correct()
        {
            new DateTime(2018, 10, 19).GetQuarter().ShouldBe(4);
            new DateTime(2019, 1, 10).GetQuarter().ShouldBe(1);
            new DateTime(2018, 6, 17).GetQuarter().ShouldBe(2);
        }

        [Fact]
        public void IsInThePast_is_correct()
        {
            new DateTime(2018, 10, 18).IsInThePast().ShouldBeTrue();
            new DateTime(2118, 11, 12).IsInThePast().ShouldBeFalse();
        }

        [Fact]
        public void IsInTheFuture_is_correct()
        {
            new DateTime(2018, 10, 18).IsInTheFuture().ShouldBeFalse();
            new DateTime(2118, 11, 12).IsInTheFuture().ShouldBeTrue();
        }
    }
}