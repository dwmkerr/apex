using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace Apex.MVVM
{
  [ContentProperty("Children")]
  public class FrameworkElementCollection<T> : FrameworkElement where T : FrameworkElement
  {
    public FrameworkElementCollection()
    {
      Children = new List<T>();
      this.Loaded += new RoutedEventHandler(OnLoaded);
    }

    void OnLoaded(object sender, RoutedEventArgs e)
    {
      foreach (FrameworkElement fe in Children)
        this.AddLogicalChild(fe);
    }

    public List<T> Children { get; set; }
  }
}
