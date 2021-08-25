using System;
using System.Globalization;
using Xamarin.Forms;

namespace ClearApp.Converters
{
    public sealed class SideColorConverter : IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture) => ToColor(value);

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture) => ToColor(value);

        #endregion

        #region Private Methods

        private static Color ToColor(object value) {
            if (!(value is string text)) return Color.Black;

            if (text.Equals("Venda"))
                return Color.FromHex("#c2052b");

            return Color.FromHex("#052fff");
        }

        #endregion
    }
}
