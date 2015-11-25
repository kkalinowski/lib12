using System;
using System.IO;
using lib12.FunctionalFlow;

namespace lib12.Misc
{
    /// <summary>
    /// Simple logger
    /// </summary>
    public static class Logger
    {
        private const string FileName = "log.txt";
        private const string Format = "{0} {1} => {2}";
        private static readonly StreamWriter file = File.CreateText(FileName);

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="text"></param>
        public static void Info(string text)
        {
            file.WriteLine(Format, DateTime.UtcNow, "INFO", text);
        }

        /// <summary>
        /// Log error message
        /// </summary>
        public static void Error(string text)
        {
            file.WriteLine(Format, DateTime.UtcNow, "ERROR", text);
        }

        /// <summary>
        /// Log exception
        /// </summary>
        public static void Error(Exception ex)
        {
            file.WriteLine(Format, DateTime.UtcNow, "ERROR", "Exception occured - " + ex.Message);

            var inner = ex.InnerException;
            while (inner.NotNull())
            {
                file.WriteLine(Format, DateTime.UtcNow, "ERROR", "Inner exception - " + inner.Message);
                inner = inner.InnerException;
            }
        }
    }
}