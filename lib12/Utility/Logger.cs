using System;
using System.IO;

namespace lib12.Utility
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

        /// <summary>
        /// Whether or not append display logged message also on Console
        /// </summary>
        public static bool DisplayAlsoOnConsole { get; set; }

        private static string ComputeFileName()
        {
            if (AppendTimeStampToFileName)
                return $"{FileName}_{DateTime.Now:yyyy-MM-dd_HH:mm:ss.fff}.txt";
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
                var line = GetFormatedLine("INFO", text);
                file.WriteLine(line);
                if (DisplayAlsoOnConsole)
                    Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        public static void Warning(string text)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                var line = GetFormatedLine("WARNING", text);
                file.WriteLine(line);
                if (DisplayAlsoOnConsole)
                    Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Log error message
        /// </summary>
        public static void Error(string text)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                var line = GetFormatedLine("ERROR", text);
                file.WriteLine(line);
                if (DisplayAlsoOnConsole)
                    Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Log exception
        /// </summary>
        public static void Error(Exception ex)
        {
            using (var file = File.AppendText(ComputeFileName()))
            {
                var line = GetFormatedLine("ERROR", "Exception occured - " + ex.Message);
                file.WriteLine(line);
                if (DisplayAlsoOnConsole)
                    Console.WriteLine(line);

                var inner = ex.InnerException;
                while (inner != null)
                {
                    line = GetFormatedLine("ERROR", "Inner exception - " + ex.Message);
                    file.WriteLine(line);
                    if (DisplayAlsoOnConsole)
                        Console.WriteLine(line);

                    inner = inner.InnerException;
                }
            }
        }
    }
}