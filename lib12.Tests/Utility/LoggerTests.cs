using System.IO;
using lib12.Misc;
using Shouldly;
using Xunit;

namespace lib12.Tests.Utility
{
    public class LoggerTests
    {
        [Fact]
        public void logger_properly_logs_messages()
        {
            Logger.AppendTimeStampToFileName = false;
            Logger.Info("some info text");
            Logger.Error("some error text");

            var logContent = File.ReadAllLines("log.txt");
            logContent.Length.ShouldBe(2);
            logContent[0].ShouldContain("some info text");
            logContent[1].ShouldContain("some error text");

            File.Delete("log.txt");
        }
    }
}