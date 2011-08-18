using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Apex.MVVM
{
    public static class EventBindings
    {

        private static readonly DependencyProperty EventBindingsProperty =
          DependencyProperty.RegisterAttached("EventBindings", typeof(EventBindingCollection), typeof(EventBindings),
          new PropertyMetadata(null, new PropertyChangedCallback(OnEventBindingsChanged)));

        public static EventBindingCollection GetEventBindings(DependencyObject o)
        {
            return (EventBindingCollection)o.GetValue(EventBindingsProperty);
        }

        public static void SetEventBindings(DependencyObject o, EventBindingCollection value)
        {
            o.SetValue(EventBindingsProperty, value);
        }

        public static void OnEventBindingsChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Cast the data.
            EventBindingCollection oldEventBindings = args.OldValue as EventBindingCollection;
            EventBindingCollection newEventBindings = args.NewValue as EventBindingCollection;

            //  If we have a new value, keep track of changes.
            if (newEventBindings != null)
            {
                foreach (var binding in newEventBindings)
                {
                    binding.DataContext = o is FrameworkElement ? ((FrameworkElement)o).DataContext : null;
                    binding.Bind(o);
                }
            }
        }

        static void newEventBindings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }
    }
}
 