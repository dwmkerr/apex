using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
    /// <summary>
    /// The StringNullOrEmptyToVisibility converter takes a string as its input.
    /// If the string is null or empty the converter will return Visibility.Collapsed, otherwise
    /// it will return Visibility.Visible. You can invert this behaviour by setting the 
    /// converter parameter to 'Invert'.
    /// </summary>
    public class StringNullOrEmptyToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //  If we don't have a string, we must fail.
            if (value is string == false)
                return Visibility.Collapsed;

            //  Get the string.
            string str = (string)value;

            //  Determine whether we are inverting.
            bool invert = (parameter is string && ((string)parameter).IndexOf("Invert", StringComparison.OrdinalIgnoreCase) != -1);

            //  Are we collapsing?
            bool collapse = string.IsNullOrEmpty(str);

            //  Apply inversion.
            if (invert)
                collapse = !collapse;

            //  Return the correct visibilty.
            return collapse ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
