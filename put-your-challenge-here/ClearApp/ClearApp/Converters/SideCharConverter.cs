using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace ClearApp.Converters
{
    public sealed class SideCharConverter : IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture) => ToFirstChar(value);

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture) => ToFirstChar(value);

        #endregion

        #region Private Methods

        private static char ToFirstChar(object value)
        {
            if (!(value is string text)) return '?';

            return text.FirstOrDefault();
        }

        #endregion
    }
}
