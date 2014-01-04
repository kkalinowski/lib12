using System;
using System.Globalization;

namespace lib12.WPF.Converters
{
    public class SubstringConverter : DynamicConverter
    {
        #region Const
        public const int DefaultLength = 20;
        #endregion

        #region Props
        public int MaxLength { get; set; }
        #endregion

        #region ctor
        public SubstringConverter()
        {
            MaxLength = DefaultLength;
        }
        #endregion

        #region Converter
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var source = value.ToString();
            return source.Length > MaxLength ? source.Substring(0, MaxLength - 3) + "..." : source;
        }
        #endregion
    }
}
