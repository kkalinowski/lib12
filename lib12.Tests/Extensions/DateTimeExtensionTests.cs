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
        public void GetWeek_is_correct()
        {
            new DateTime(2018, 10, 19).GetWeek().ShouldBe(42);
            new DateTime(2019, 1, 10).GetWeek().ShouldBe(2);
            new DateTime(2019, 1, 3).GetWeek().ShouldBe(1);
            new DateTime(2012, 12, 31).GetWeek().ShouldBe(1);
            new DateTime(2016, 1, 2).GetWeek().ShouldBe(53);
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
        public void IsInPast_is_correct()
        {
            new DateTime(2018, 10, 18).IsInPast().ShouldBeTrue();
            new DateTime(2118, 11, 12).IsInPast().ShouldBeFalse();
        }

        [Fact]
        public void IsInFuture_is_correct()
        {
            new DateTime(2018, 10, 18).IsInFuture().ShouldBeFalse();
            new DateTime(2118, 11, 12).IsInFuture().ShouldBeTrue();
        }

        [Fact]
        public void IsWorkday_is_correct()
        {
            new DateTime(2018, 10, 18).IsWorkday().ShouldBeTrue();
            new DateTime(2018, 10, 21).IsWorkday().ShouldBeFalse();
        }

        [Fact]
        public void IsWeekend_is_correct()
        {
            new DateTime(2018, 10, 18).IsWeekend().ShouldBeFalse();
            new DateTime(2018, 10, 21).IsWeekend().ShouldBeTrue();
        }

        [Fact]
        public void GetStartOfWeek_is_correct()
        {
            new DateTime(2018, 10, 18, 14, 56, 10).GetStartOfWeek().ShouldBe(new DateTime(2018, 10, 15));
            new DateTime(2018, 10, 8).GetStartOfWeek().ShouldBe(new DateTime(2018, 10, 8));
            new DateTime(2018, 10, 14).GetStartOfWeek().ShouldBe(new DateTime(2018, 10, 8));
            new DateTime(2012, 12, 31).GetStartOfWeek().ShouldBe(new DateTime(2012, 12, 31));
            new DateTime(2016, 1, 2).GetStartOfWeek().ShouldBe(new DateTime(2015, 12, 28));
        }

        [Fact]
        public void GetEndOfWeek_is_correct()
        {
            new DateTime(2018, 10, 18, 14, 56, 10).GetEndOfWeek().ShouldBe(new DateTime(2018, 10, 21, 23, 59, 59));
            new DateTime(2000, 2, 21).GetEndOfWeek().ShouldBe(new DateTime(2000, 2, 27, 23, 59, 59));
            new DateTime(2018, 10, 8).GetEndOfWeek().ShouldBe(new DateTime(2018, 10, 14, 23, 59, 59));
            new DateTime(2018, 10, 14).GetEndOfWeek().ShouldBe(new DateTime(2018, 10, 14, 23, 59, 59));
            new DateTime(2012, 12, 31).GetEndOfWeek().ShouldBe(new DateTime(2013, 1, 6, 23, 59, 59));
            new DateTime(2016, 1, 2).GetEndOfWeek().ShouldBe(new DateTime(2016, 1, 3, 23, 59, 59));
        }

        [Fact]
        public void GetStartOfMonth_is_correct()
        {
            new DateTime(2018, 10, 18, 14, 56, 10).GetStartOfMonth().ShouldBe(new DateTime(2018, 10, 1));
            new DateTime(2019, 2, 21).GetStartOfMonth().ShouldBe(new DateTime(2019, 2, 1));
        }

        [Fact]
        public void GetEndOfMonth_is_correct()
        {
            new DateTime(2018, 10, 18, 14, 56, 10).GetEndOfMonth().ShouldBe(new DateTime(2018, 10, 31, 23, 59, 59));
            new DateTime(2000, 2, 21).GetEndOfMonth().ShouldBe(new DateTime(2000, 2, 29, 23, 59, 59));
        }

        [Fact]
        public void GetYesterday_is_correct()
        {
            new DateTime(2019, 1, 28).GetYesterday().ShouldBe(new DateTime(2019, 1, 27, 0, 0, 0));
            new DateTime(2019, 1, 1).GetYesterday().ShouldBe(new DateTime(2018, 12, 31, 0, 0, 0));
        }

        [Fact]
        public void GetTomorrow_is_correct()
        {
            new DateTime(2019, 1, 28).GetTomorrow().ShouldBe(new DateTime(2019, 1, 29, 0, 0, 0));
            new DateTime(2018, 12, 31).GetTomorrow().ShouldBe(new DateTime(2019, 1, 1, 0, 0, 0));
        }
    }
}