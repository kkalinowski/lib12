using System;
using System.Globalization;
using System.Windows.Media;

namespace lib12.WPF.Converters
{
    public class BrushToColorConverter : StaticConverter<BrushToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = value as SolidColorBrush;
            if (brush != null)
                throw new ArgumentException("You must provide SolidColorBrush for this converter");

            return brush.Color;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
    }
}
