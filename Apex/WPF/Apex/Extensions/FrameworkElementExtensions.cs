using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

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
  }
}
