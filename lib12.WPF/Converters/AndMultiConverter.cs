using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using lib12.Collections;

namespace lib12.WPF.Converters
{
    public sealed class AndMultiConverter : StaticMultiConverter<AndMultiConverter>
    {
        #region IMultiValueConverter
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => x == DependencyProperty.UnsetValue))
                return false;

            var result = true;
            values.Cast<bool>().ForEach(x => { result = result && x; });
            return result;
        }
        #endregion
    }
}
