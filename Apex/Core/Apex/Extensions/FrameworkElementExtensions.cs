using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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

    public static BitmapSource RenderBitmap(this FrameworkElement element)
    {
#if SILVERLIGHT

      //  We'll use the writable bitmap.
      WriteableBitmap wb = new WriteableBitmap((int)element.ActualWidth, (int)element.ActualHeight);
      wb.Render(element, new TranslateTransform());
      wb.Invalidate();
      return wb;

#else

      //  We're in WPF, so use the render bitmap.


      
      //  Create a visual brush from the element.
        VisualBrush elementBrush = new VisualBrush(element);

      //  Create a visual.
        DrawingVisual visual = new DrawingVisual();

      //  Open the visual to get a drawing context.
        DrawingContext dc = visual.RenderOpen();

      //  Draw the element in the appropriately sized rectangle.
        dc.DrawRectangle(elementBrush, null, new Rect(0, 0, element.ActualWidth, element.ActualHeight));

      //  Close the drawing context.
        dc.Close();
      
      //  WPF uses 96 DPI - this is defined in System.Windows.SystemParameters.DPI
      //  but it is internal, so we must use a magic number.
      double systemDPI = 96;
      
      //  Create the bitmap and render it.
      RenderTargetBitmap bitmap = new RenderTargetBitmap((int)element.ActualWidth, (int)element.ActualHeight, systemDPI, systemDPI, PixelFormats.Default);
      bitmap.Render(visual);

      //  Return the bitmap.
        return bitmap;
#endif
    }
  }
}
