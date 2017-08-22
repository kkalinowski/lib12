using System.Windows.Controls.Primitives;

namespace lib12.WPF.Extensions
{
    public static class PopupExtension
    {
        /// <summary>
        /// Opens popup
        /// </summary>
        public static void Open(this Popup popup)
        {
            popup.IsOpen = true;
        }

        /// <summary>
        /// Closes popup
        /// </summary>
        public static void Close(this Popup popup)
        {
            popup.IsOpen = false;
        }
    }
}
