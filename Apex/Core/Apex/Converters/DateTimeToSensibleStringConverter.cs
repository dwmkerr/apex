using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
    /// <summary>
    /// Converts a DateTime to a more sensible string.
    /// </summary>
    public class DateTimeToSensibleStringConverter : IValueConverter
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
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //  Cast the value.
            DateTime dateTime;
            try
            {
                dateTime = (DateTime) value;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("The value provided to a DateTimeToSensibleStringConverter could not be cast to a DateTime.", exception);
            }
            
            //  Depending on the date portion, create the date part of the string.
            string datePart = dateTime.ToShortDateString() + " ";
            if (dateTime.Date == DateTime.Now.AddDays(1).Date)
                datePart = "Tomorrow at ";
            else if (dateTime.Date == DateTime.Now.Date)
                datePart = "Today at ";
            else if (dateTime.Date == DateTime.Now.Subtract(TimeSpan.FromDays(1)).Date)
                datePart = "Yesterday at ";

            return datePart + dateTime.ToShortTimeString();
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
            throw new NotImplementedException("ConvertBack is NOT supported for DateTimeToSensibleStringConverter.");
        }
    }
}
