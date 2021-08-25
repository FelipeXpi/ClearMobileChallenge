using System;
using System.Globalization;
using Xamarin.Forms;

namespace ClearApp.Converters
{
    public sealed class PrefixTextConverter : IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture) => ToPrefixedText(value, parameter);

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture) => ToPrefixedText(value, parameter);

        #endregion

        #region Private Methods

        private static string ToPrefixedText(object value, object prefix)
        {
            if (!(value is string text))
                return string.Empty;

            return $"{prefix} {text}";
        }

        #endregion
    }
}
