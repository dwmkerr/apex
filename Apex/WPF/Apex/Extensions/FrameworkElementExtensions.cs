using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Apex.Extensions
{
  internal static class FrameworkElementExtensions
  {
#if !SILVERLIGHT
    /// <summary>
    /// Get the window container of framework element.
    /// </summary>
    public static Window GetParentWindow(this FrameworkElement element)
    {
      DependencyObject dp = element;
      while (dp != null)
      {
        DependencyObject tp = LogicalTreeHelper.GetParent(dp);
        if (tp is Window) return tp as Window;
        else dp = tp;
      }
      return null;
    }
#endif
    public static FrameworkElement GetTopLevelParent(this FrameworkElement element)
    {
      FrameworkElement p = element;
      while(p != null)
      {
        if (p.Parent == null)
          return p;
        p = p.Parent as FrameworkElement;
      }
      return null;
    }

    public static RenderTargetBitmap RenderBitmap(this FrameworkElement element)
    {


        double topLeft = 0;

        double topRight = 0;

        int width = (int)element.ActualWidth;

        int height = (int)element.ActualHeight;

        double dpiX = 96; // this is the magic number

        double dpiY = 96; // this is the magic number

        PixelFormat pixelFormat = PixelFormats.Default;

        VisualBrush elementBrush = new VisualBrush(element);

        DrawingVisual visual = new DrawingVisual();

        DrawingContext dc = visual.RenderOpen();

        dc.DrawRectangle(elementBrush, null, new Rect(topLeft, topRight, width, height));

        dc.Close();

        RenderTargetBitmap bitmap = new RenderTargetBitmap(width, height, dpiX, dpiY, pixelFormat);

        bitmap.Render(visual);

        return bitmap;

    }
  }
}
