using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Commands
{

  public class EventBindingCollection : FreezableCollection<EventBinding>// FrameworkElementCollection<EventBinding>
    {
    public EventBindingCollection()
    {
      //Loaded += new RoutedEventHandler(EventBindingCollection_Loaded);
    }
    /*
    void EventBindingCollection_Loaded(object sender, RoutedEventArgs e)
    {
      foreach (var child in this)
      {
        AddLogicalChild(child);
        child.Bind(Parent);
      }
    }
    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      foreach (var child in this)
      {
        AddLogicalChild(child);
        child.Bind(Parent);
      }
    }*/
    }
}
