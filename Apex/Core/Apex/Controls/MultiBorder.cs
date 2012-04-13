using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Apex.Controls
{
  public class MultiBorder : ContentControl
  {
    static MultiBorder()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiBorder), new FrameworkPropertyMetadata(typeof(MultiBorder)));
    }

    public static DependencyProperty BorderBrushLeftProperty = DependencyProperty.Register("BorderBrushLeft", typeof(Brush), typeof(MultiBorder));
    public static DependencyProperty BorderBrushTopProperty = DependencyProperty.Register("BorderBrushTop", typeof(Brush), typeof(MultiBorder));
    public static DependencyProperty BorderBrushRightProperty = DependencyProperty.Register("BorderBrushRight", typeof(Brush), typeof(MultiBorder));
    public static DependencyProperty BorderBrushBottomProperty = DependencyProperty.Register("BorderBrushBottom", typeof(Brush), typeof(MultiBorder));
    public static DependencyProperty BorderThicknessLeftProperty = DependencyProperty.Register("BorderThicknessLeft", typeof(double), typeof(MultiBorder),
      new PropertyMetadata(1.0));
    public static DependencyProperty BorderThicknessTopProperty = DependencyProperty.Register("BorderThicknessTop", typeof(double), typeof(MultiBorder),
      new PropertyMetadata(1.0));
    public static DependencyProperty BorderThicknessRightProperty = DependencyProperty.Register("BorderThicknessRight", typeof(double), typeof(MultiBorder),
      new PropertyMetadata(1.0));
    public static DependencyProperty BorderThicknessBottomProperty = DependencyProperty.Register("BorderThicknessBottom", typeof(double), typeof(MultiBorder),
      new PropertyMetadata(1.0));

    public Brush BorderBrushLeft
    {
      get { return (Brush)GetValue(BorderBrushLeftProperty); }
      set { SetValue(BorderBrushLeftProperty, value); }
    }

    public Brush BorderBrushTop
    {
      get { return (Brush)GetValue(BorderBrushTopProperty); }
      set { SetValue(BorderBrushTopProperty, value); }
    }

    public Brush BorderBrushRight
    {
      get { return (Brush)GetValue(BorderBrushRightProperty); }
      set { SetValue(BorderBrushRightProperty, value); }
    }

    public Brush BorderBrushBottom
    {
      get { return (Brush)GetValue(BorderBrushBottomProperty); }
      set { SetValue(BorderBrushBottomProperty, value); }
    }

    public double BorderThicknessLeft
    {
      get { return (double)GetValue(BorderThicknessLeftProperty); }
      set { SetValue(BorderThicknessLeftProperty, value); }
    }

    public double BorderThicknessTop
    {
      get { return (double)GetValue(BorderThicknessTopProperty); }
      set { SetValue(BorderThicknessTopProperty, value); }
    }

    public double BorderThicknessRight
    {
      get { return (double)GetValue(BorderThicknessRightProperty); }
      set { SetValue(BorderThicknessRightProperty, value); }
    }

    public double BorderThicknessBottom
    {
      get { return (double)GetValue(BorderThicknessBottomProperty); }
      set { SetValue(BorderThicknessBottomProperty, value); }
    }
  }
}
