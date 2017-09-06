using System;
using System.IO;

namespace lib12.Misc
{
    /// <summary>
    /// Helper functions for IO
    /// </summary>
    public static class IoHelper
    {
        /// <summary>
        /// Gets the application data path.
        /// </summary>
        /// <returns></returns>
        public static string GetAppDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        /// <summary>
        /// Creates the directory if not exist.
        /// </summary>
        /// <param name="path">The path to directory to check</param>
        public static void CreateDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Safely deletes file if it exists
        /// </summary>
        /// <returns></returns>
        public static void DeleteIfExists(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            else if (Directory.Exists(path))
                Directory.Delete(path);
        }
    }
}
