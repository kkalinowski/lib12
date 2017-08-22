using System.Windows.Controls;

namespace lib12.WPF.Extensions
{
    public static class ContextMenuExtension
    {
        /// <summary>
        /// Opens context menu
        /// </summary>
        public static void Open(this ContextMenu contextMenu)
        {
            contextMenu.IsOpen = true;
        }

        /// <summary>
        /// Closes context menu
        /// </summary>
        public static void Close(this ContextMenu contextMenu)
        {
            contextMenu.IsOpen = false;
        }
    }
}
