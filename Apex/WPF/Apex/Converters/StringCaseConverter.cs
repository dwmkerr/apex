using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Apex.Converters
{
  public class StringCaseConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      //  Cast the data.
      if (value is string == false || parameter == null)
        return null;

      string str = value as string;

      if (parameter.ToString() == "Upper")
        return str.ToUpper();
      else if (parameter.ToString() == "Lower")
        return str.ToLower();
      else
        return str;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
