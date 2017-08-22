using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace lib12.WPF.Extensions
{
    public static class DependencyObjectExtension
    {
        public static bool IsValid(this DependencyObject dObject)
        {
            return !Validation.GetHasError(dObject);
        }

        public static void RefreshBinding(this DependencyObject dObject, DependencyProperty dProperty)
        {
            BindingOperations.GetBindingExpression(dObject, dProperty).UpdateSource();
        }
    }
}
