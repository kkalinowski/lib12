using System;
using FluentAssertions;
using lib12.Extensions;
using Xunit;

namespace lib12.Test.Extensions
{
    public class DateTimeExtensionTests
    {
        [Fact]
        public void datetime_converts_properly_to_unix_timestamp()
        {
            var dateTime = new DateTime(2014, 01, 30, 12, 0, 0);

            dateTime.ToUnixTimeStamp().Should().Be(1391083200);
        }

        [Fact]
        public void datetime_parses_properly_from_unix_timestamp()
        {
            const long toParse = 1391083200;
            DateTimeExtension.ParseUnixTimeStamp(toParse).Should().Be(new DateTime(2014, 01, 30, 12, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}