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
            return string.Empty;
            //return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        /// <summary>
        /// Creates the directory if not exist.
        /// </summary>
        /// <param name="path">The path to directory to check</param>
        public static void CreateDirectoryIfNotExist(string path)
        {
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Gets the default path of current computer - first hard drive's root
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPath()
        {
            return string.Empty;
            //return DriveInfo.GetDrives().First(x => x.IsReady).RootDirectory.FullName;
        }
    }
}
