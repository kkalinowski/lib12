using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using lib12.Collections;

namespace lib12.WPF.Converters
{
    public sealed class OrMultiConverter : StaticMultiConverter<OrMultiConverter>
    {
        #region IMultiValueConverter
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => x == DependencyProperty.UnsetValue))
                return false;

            var result = false;
            values.Cast<bool>().ForEach(x => { result = result || x; });
            return result;
        }
        #endregion
    }
}
