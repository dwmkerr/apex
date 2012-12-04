using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
    /// <summary>
    /// Converts by dividing a double by two.
    /// </summary>
  public class DivideByTwoConverter : IValueConverter
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
      if (value != null && value is double)
      {
        if (parameter != null && parameter is string && (string)parameter == "Negative")
          return -((double)value) / 2;
        else
          return ((double)value) / 2;

      }
      return 0.0;
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
