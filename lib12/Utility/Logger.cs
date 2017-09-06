using System;
using System.IO;
using lib12.Extensions;

namespace lib12.Misc
{
    /// <summary>
    /// Simple logger
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// File name of log file
        /// </summary>
        public static string FileName { get; set; } = "log";

        /// <summary>
        /// Whether or not append time stamp to filename describing when it was created.
        /// </summary>
        public static bool AppendTimeStampToFileName { get; set; } = true;

        private static string ComputeFileName()
        {
            if (AppendTimeStampToFileName)
                return $"{FileName}_{DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.fff")}.txt";
            else
                return $"{FileName}.txt";
        }

        private static string GetFormatedLine(string level, string text)
        {
            return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {level} => {text}";
        }

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="text"></param>
        public static void Info(string text)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                file.WriteLine(GetFormatedLine("INFO", text));
            }
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        public static void Warning(string text)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                file.WriteLine(GetFormatedLine("WARNING", text));
            }
        }

        /// <summary>
        /// Log error message
        /// </summary>
        public static void Error(string text)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                file.WriteLine(GetFormatedLine("ERROR", text));
            }
        }

        /// <summary>
        /// Log exception
        /// </summary>
        public static void Error(Exception ex)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                file.WriteLine(GetFormatedLine("ERROR", "Exception occured - " + ex.Message));

                var inner = ex.InnerException;
                while (inner.IsNotNull())
                {
                    file.WriteLine(GetFormatedLine("ERROR", "Inner exception - " + ex.Message));
                    inner = inner.InnerException;
                }
            }
        }
    }
}