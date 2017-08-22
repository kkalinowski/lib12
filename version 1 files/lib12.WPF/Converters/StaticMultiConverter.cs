using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace lib12.WPF.Converters
{
    public abstract class StaticMultiConverter<T> : MarkupExtension, IMultiValueConverter where T : class, new()
    {
        #region Markup extension
        public static readonly T Instance = new T();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        #endregion

        #region IMultiValueConverter
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
