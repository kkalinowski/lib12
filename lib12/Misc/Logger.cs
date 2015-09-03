using System;
using System.IO;

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
    }
}