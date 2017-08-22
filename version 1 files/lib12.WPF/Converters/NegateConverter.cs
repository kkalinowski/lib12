using System;
using System.Globalization;

//
//author: Krzysztof Kalinowski
//

namespace lib12.WPF.Converters
{
    public class NegateConverter : StaticConverter<NegateConverter>
    {
        #region Converter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
        #endregion
    }
}
