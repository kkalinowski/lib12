using System;
using System.Windows;
using System.Windows.Media;

namespace lib12.WPF.Extensions
{
    public static class ApplicationExtension
    {
        /// <summary>
        /// Finds the style in application resources
        /// </summary>
        /// <param name="key">Key of searched resource</param>
        public static Style FindStyle(this Application application, object key)
        {
            return (Style)application.FindResource(key);
        }

        /// <summary>
        /// Finds the brush in application resources
        /// </summary>
        /// <param name="key">Key of searched resource</param>
        public static Brush FindBrush(this Application application, object key)
        {
            return (Brush)application.FindResource(key);
        }

        public static void AddResourceDictionary(this Application application, string path)
        {
            var dictionary = Application.LoadComponent(new Uri(path, UriKind.Relative)) as ResourceDictionary;
            dictionary.Source = new Uri(path, UriKind.Relative);
            application.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
