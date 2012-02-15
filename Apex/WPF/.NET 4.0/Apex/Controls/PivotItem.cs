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
using System.Windows.Markup;
using Apex.MVVM;

namespace Apex.Controls
{
  [ContentProperty("Content")]
  public class PivotItem : DependencyObject
  {
    public PivotItem()
    {
    }

    private void Select()
    {
    }
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PivotItem));
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(PivotItem));
    public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(PivotItem), 
      new PropertyMetadata(false));
  
    public Command selectedCommand;

    public string Title
    {
      get { return GetValue(TitleProperty) as string; }
      set { SetValue(TitleProperty, value); }
    }

    public object Content
    {
      get { return GetValue(ContentProperty); }
      set { SetValue(ContentProperty, value); }
    }

    public bool IsSelected
    {
      get { return (bool)GetValue(IsSelectedProperty); }
      set { SetValue(IsSelectedProperty, value); }
    }

    
    private static readonly DependencyProperty IsInitialPageProperty =
      DependencyProperty.Register("IsInitialPage", typeof(bool), typeof(PivotItem),
      new PropertyMetadata(false, new PropertyChangedCallback(OnIsInitialPageChanged)));

    public bool IsInitialPage
    {
        get { return (bool)GetValue(IsInitialPageProperty); }
        set { SetValue(IsInitialPageProperty, value); }
    }

    private static void OnIsInitialPageChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
    {
        PivotItem me = o as PivotItem;
    }
                
  }
}
