using System;
using System.Globalization;
using Xamarin.Forms;

namespace Game.Helpers
{
    public class StatToPercentageConverter : IValueConverter
    {
        /// <summary>
        /// If value is an integer between 0 and 10, converts to a percentage
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue && intValue >= 0 && intValue <= 10)
            {
                return intValue / 10f;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
