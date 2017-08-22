using System;
using System.Globalization;
using System.Windows;

namespace lib12.WPF.Converters
{
    public sealed class BoolToVisibilityConverter : DynamicConverter
    {
        #region Props
        public bool Negate { get; set; }
        #endregion

        #region Converter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Negate)
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            else
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Negate)
                return (Visibility)value != Visibility.Visible;
            else
                return (Visibility)value == Visibility.Visible;
        }
        #endregion
    }
}
