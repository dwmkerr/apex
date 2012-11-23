using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
    /// <summary>
    /// The EnumIsToVisibilityConverter returns Visibility.Visible if the provided
    /// enumeration is equal to the parameter, otherwise it returns Visibility.Collapsed.
    /// </summary>
    public class EnumIsToVisibilityConverter : IValueConverter
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
            //  The value must be an enumerator.
            if (value == null || value is Enum == false)
                throw new InvalidOperationException(
                    "The value passed to an EnumIsToVisibilityConverter must be an enumeration.");

            //  The parameter must be a string.
            if (parameter == null || parameter is string == false)
                throw new InvalidOperationException(
                    "The parameter passed to an EnumIsVisibilityConverter must be a string.");

            //  Convert it to a string.
            var enumString = value.ToString();

            //  Get target value.
            var check = parameter.ToString();

            return enumString == check ? Visibility.Visible : Visibility.Collapsed;
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
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}