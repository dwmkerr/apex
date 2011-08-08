using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Apex.Controls
{
  public class AnimatedScrollViewer : ScrollViewer
  {
    public AnimatedScrollViewer()
    {
      SizeChanged += new SizeChangedEventHandler(AnimatedScrollViewer_SizeChanged);
    }

    void AnimatedScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      double dX = e.PreviousSize.Width - e.NewSize.Width;
      double dY = e.PreviousSize.Height - e.NewSize.Height;

      //CurrentHorizontalOffset += dX;// / 2;
  //    ScrollToHorizontalOffset(CurrentHorizontalOffset + dX);
   //   CurrentVerticalOffset += dY; /// 2;
     }

    public static DependencyProperty CurrentVerticalOffsetProperty = DependencyProperty.Register("CurrentVerticalOffset", typeof(double), typeof(AnimatedScrollViewer), new PropertyMetadata(new PropertyChangedCallback(OnVerticalChanged)));

    public static DependencyProperty CurrentHorizontalOffsetProperty = DependencyProperty.Register("CurrentHorizontalOffsetOffset", typeof(double), typeof(AnimatedScrollViewer), new PropertyMetadata(new PropertyChangedCallback(OnHorizontalChanged)));

    private static void OnVerticalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      AnimatedScrollViewer viewer = d as AnimatedScrollViewer;
      viewer.ScrollToVerticalOffset((double)e.NewValue);
    }

    private static void OnHorizontalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      AnimatedScrollViewer viewer = d as AnimatedScrollViewer;
      viewer.ScrollToHorizontalOffset((double)e.NewValue);
    }

    public double CurrentHorizontalOffset
    {
      get { return (double)this.GetValue(CurrentHorizontalOffsetProperty); }
      set { this.SetValue(CurrentHorizontalOffsetProperty, value); }
    }

    public double CurrentVerticalOffset
    {
      get { return (double)this.GetValue(CurrentVerticalOffsetProperty); }
      set { this.SetValue(CurrentVerticalOffsetProperty, value); }
    }
  }
}
