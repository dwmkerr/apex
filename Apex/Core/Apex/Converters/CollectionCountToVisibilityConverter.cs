using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
    /// <summary>
    /// Converts a collection with count > 0 to true, or false otherwise. Result can be inverted by
    /// provided 'Invert' as the parameter.
    /// </summary>
    public class CollectionCountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collection = (ICollection)value;
            var invert = parameter != null && string.Compare(parameter.ToString(), "invert", StringComparison.InvariantCultureIgnoreCase) == 0;
            return (invert ? collection.Count == 0 : collection.Count > 0)? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
