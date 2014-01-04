using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace lib12.WPF.Converters
{
    public abstract class StaticConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        #region Markup extension
        public static readonly T Instance = new T();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
        #endregion

        #region IValueConverter
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
