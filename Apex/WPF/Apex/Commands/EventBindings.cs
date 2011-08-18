using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;

namespace Apex.Commands
{
    public static class EventBindings
    {

        private static readonly DependencyProperty EventBindingsProperty =
          DependencyProperty.RegisterAttached("EventBindings", typeof(ObservableCollection<EventBinding>), typeof(EventBindings),
          new PropertyMetadata(null, new PropertyChangedCallback(OnEventBindingsChanged)));

        public static ObservableCollection<EventBinding> GetEventBindings(DependencyObject o)
        {
            return (ObservableCollection<EventBinding>)o.GetValue(EventBindingsProperty);
        }

        public static void SetEventBindings(DependencyObject o, ObservableCollection<EventBinding> value)
        {
            o.SetValue(EventBindingsProperty, value);
        }

        public static void OnEventBindingsChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
        }
    }
}
