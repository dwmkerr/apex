using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Apex.Converters
{
  [ValueConversion(typeof(bool), typeof(System.Windows.Visibility))]
  public class FalseToCollapsedConverter : IValueConverter
  {
    #region IValueConverter Members

    object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      bool b = (bool)value;

      return b ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
