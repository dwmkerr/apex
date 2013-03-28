﻿using System;
using System.Windows;
using System.Windows.Data;

namespace Apex.Converters
{
    /// <summary>
    /// Converter to invert a boolean.
    /// </summary>
    public class InvertedBooleanConverter : IValueConverter
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
            //  Cast the data to a bool.
            bool booleanValue;
            try
            {
                booleanValue = (bool) value;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("The value provided to an InvertedBooleanConverter could not be cast to a boolean.", exception);
            }

            return !booleanValue;
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
            throw new NotImplementedException("ConvertBack is NOT supported for the InvertedBooleanConverter.");
        }

        #endregion
    }
}