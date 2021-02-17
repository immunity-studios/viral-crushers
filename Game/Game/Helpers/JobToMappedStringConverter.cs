using Game.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Game.Helpers
{
    public class JobToMappedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CharacterJobEnum enumValue)
            {
                return CharacterJobEnumHelper.ConvertEnumToMappedString(enumValue);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return CharacterJobEnumHelper.ConvertMappedStringToEnum(stringValue);
            }

            return value;
        }
    }
}
