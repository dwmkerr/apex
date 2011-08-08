using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;
using System.Windows.Media.Imaging;

namespace Apex.Converters
{
  public class ByteArrayToImageSourceConverter : IValueConverter
  {
    object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if(value is byte[] == false)
        return null;

      MemoryStream stream = new MemoryStream((byte[])value);
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.StreamSource = stream;
      bitmapImage.EndInit();

      return bitmapImage;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }

  }
}