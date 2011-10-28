using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Apex.Extensions;
using Apex.Consistency;

namespace Apex.Commands
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

            //  If we have new set of event bindings, bind each one.
            if (newEventBindings != null)
            {
                foreach (EventBinding binding in newEventBindings)
                {
                    binding.Bind(o);
#if SILVERLIGHT
                    //  If we're in Silverlight we don't inherit the
                    //  data context so we must set this helper variable.
                    binding.ParentElement = o as FrameworkElement;
#endif
                }
            }
        }
    }
}
 