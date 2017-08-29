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
        public void isempty_returns_true_on_empty_datetime()
        {
            new DateTime().IsEmpty().ShouldBeTrue();
        }

        [Fact]
        public void isempty_returns_false_on_non_empty_datetime()
        {
            new DateTime(1900, 3, 25).IsEmpty().ShouldBeFalse();
        }
    }
}