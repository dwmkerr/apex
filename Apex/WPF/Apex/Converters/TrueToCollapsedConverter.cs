using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Apex.Converters
{
  [ValueConversion(typeof(bool), typeof(System.Windows.Visibility))]
  public class TrueToCollapsedConverter : IValueConverter
  {
    #region IValueConverter Members

    object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      bool b = (bool)value;

      return b ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
