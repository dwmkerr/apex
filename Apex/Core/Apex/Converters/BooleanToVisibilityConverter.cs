using System;
using System.Windows;

namespace Apex.Converters
{
    /// <summary>
    /// Standard boolean to visibility converter that supports inversion.
    /// </summary>
    public class BooleanToVisibilityConverter : InvertableConverter
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
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //  Cast the data to a bool.
            bool booleanValue;
            try
            {
                booleanValue = (bool) value;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("The value provided to a BooleanToVisibilityConverter could not be cast to a boolean.", exception);
            }

            //  Are we inverting?
            var invert = IsInverted(parameter);

            //  Return the appropriate visibility.
            if(invert)
                return booleanValue ? Visibility.Collapsed : Visibility.Visible;
            return booleanValue ? Visibility.Visible : Visibility.Collapsed;
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
        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack is NOT supported for the BooleanToVisibilityConverter.");
        }

        #endregion
    }
}