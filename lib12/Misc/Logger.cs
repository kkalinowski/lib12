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
        private const string Format = "{0} {1} => {2}";

        /// <summary>
        /// File name of log file
        /// </summary>
        public static string FileName { get; set; } = "log.txt";

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="text"></param>
        public static void Info(string text)
        {
            //using (var file = File.AppendText(FileName))
            //{
            //    file.WriteLine(Format, DateTime.UtcNow, "INFO", text);
            //}
        }

        /// <summary>
        /// Log error message
        /// </summary>
        public static void Error(string text)
        {
            //using (var file = File.AppendText(FileName))
            //{
            //    file.WriteLine(Format, DateTime.UtcNow, "ERROR", text);
            //}
        }

        /// <summary>
        /// Log exception
        /// </summary>
        public static void Error(Exception ex)
        {
            //using (var file = File.AppendText(FileName))
            //{
            //    file.WriteLine(Format, DateTime.UtcNow, "ERROR", "Exception occured - " + ex.Message);

            //    var inner = ex.InnerException;
            //    while (inner.NotNull())
            //    {
            //        file.WriteLine(Format, DateTime.UtcNow, "ERROR", "Inner exception - " + inner.Message);
            //        inner = inner.InnerException;
            //    }
            //}
        }
    }
}