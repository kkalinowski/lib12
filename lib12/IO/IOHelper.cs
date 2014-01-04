using System;
using System.IO;
using System.Linq;

namespace lib12.IO
{
    public static class IOHelper
    {
        public static string GetAppDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static void CreateDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Gets the default path of current computer - first hard drive's root
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPath()
        {
            return DriveInfo.GetDrives().First(x => x.IsReady).RootDirectory.FullName;
        }
    }
}
