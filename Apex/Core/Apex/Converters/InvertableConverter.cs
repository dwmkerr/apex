using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Apex.Converters
{
    /// <summary>
    /// An InvertableConverter is a base for all converters that can be inverted with the parameter 'Invert'.
    /// </summary>
    public abstract class InvertableConverter : IValueConverter
    {
        /// <summary>
        /// The invert string.
        /// </summary>
        private const string InvertString = @"Invert";

        /// <summary>
        /// Determines whether the converter is inverted based on the parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///   <c>true</c> if the specified parameter is inverted; otherwise, <c>false</c>.
        /// </returns>
        protected static bool IsInverted(object parameter)
        {
            //  We're inverted if we have a parameter, and it matches the string 'invert'.
            return parameter != null &&
                   string.Compare(parameter.ToString(), InvertString, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

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
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

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
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
