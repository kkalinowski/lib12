using System;
using System.Windows;
using System.Windows.Threading;

namespace lib12.WPF.Core
{
    public static class WpfUtilities
    {
        public static void ThreadSafeInvoke(DispatcherPriority priority, Action action)
        {
            if (Application.Current.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                Application.Current.Dispatcher.Invoke(priority, new Action(delegate()
                {
                    action.Invoke();
                }));
            }
        }

        public static void ThreadSafeInvoke(Action action)
        {
            ThreadSafeInvoke(DispatcherPriority.Send, action);
        }

        public static Visibility ReverseVisibility(Visibility visibility)
        {
            return visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
