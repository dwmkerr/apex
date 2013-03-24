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
    public class CollectionCountToBooleanConverter : InvertableConverter
    {
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
        /// <exception cref="System.InvalidOperationException">The value provided to a CollectionCountToBooleanConverter could not be cast to an ICollection.</exception>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //  Try and cast the collection.
            ICollection collection;
            try
            {
                collection = (ICollection)value;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("The value provided to a CollectionCountToBooleanConverter could not be cast to an ICollection.", exception);
            }

            //  Are we inverting.
            var invert = IsInverted(parameter);
            
            //  Return the appropriate value.
            return invert ? collection.Count == 0 : collection.Count > 0;
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
        /// <exception cref="System.NotImplementedException">ConvertBack is NOT supported for CollectionCountToBooleanConverter.</exception>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack is NOT supported for CollectionCountToBooleanConverter.");
        }
    }
}
