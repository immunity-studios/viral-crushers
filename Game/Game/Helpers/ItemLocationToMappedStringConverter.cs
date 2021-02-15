using Game.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Game.Helpers
{
    public class ItemLocationToMappedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ItemLocationEnum enumValue)
            {
                return ItemLocationEnumHelper.ConvertEnumToMappedString(enumValue);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return ItemLocationEnumHelper.ConvertMappedStringToEnum(stringValue);
            }

            return value;
        }
    }
}
