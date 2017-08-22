using System;
using System.Globalization;

namespace lib12.WPF.Converters
{
    public sealed class ReferenceToBoolConverter : StaticConverter<ReferenceToBoolConverter>
    {
        #region Converter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }
        #endregion
    }
}
