using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
    public class DateTimeToSensibleStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          //  Bail if we do not have a date time.
          if (value == null || value is DateTime == false)
            return null;

            //  The value must be a datetime.
            DateTime dateTime = (DateTime)value;

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

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
