using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Apex.Behaviours
{

    /// <summary>
    /// Container for the Behaviours attached dependency property.
    /// </summary>
    public class Behaviours
    {
        /// <summary>
        /// The Behaviours Dependency Property.
        /// </summary>
        private static readonly DependencyProperty BehavioursProperty =
          DependencyProperty.RegisterAttached("Behaviours", typeof(BehaviourCollection), typeof(FrameworkElement),
          new PropertyMetadata(null, new PropertyChangedCallback(OnBehavioursChanged)));

        /// <summary>
        /// Gets the behaviours.
        /// </summary>
        /// <param name="o">The object.</param>
        /// <returns>The behaviours</returns>
        public static BehaviourCollection GetBehaviours(DependencyObject o)
        {
            return (BehaviourCollection)o.GetValue(BehavioursProperty);
        }

        /// <summary>
        /// Sets the behaviours.
        /// </summary>
        /// <param name="o">The object.</param>
        /// <param name="attachedBehaviours">The attached behaviours.</param>
        public static void SetBehaviours(DependencyObject o, BehaviourCollection attachedBehaviours)
        {
            o.SetValue(BehavioursProperty, attachedBehaviours);
        }

        /// <summary>
        /// Called when behaviours are changed
        /// </summary>
        /// <param name="o">The object.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnBehavioursChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement me = o as FrameworkElement;
            if (args.NewValue is BehaviourCollection)
            {
                BehaviourCollection attachedBehaviours = (BehaviourCollection)args.NewValue;
                attachedBehaviours.CollectionChanged += (sender, e) =>
                {
                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                        foreach (IBehaviour newItem in e.NewItems)
                            newItem.Attach(me);
                    else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                        foreach (IBehaviour newItem in e.NewItems)
                            newItem.Detach(me);
                };
                foreach (var behaviour in attachedBehaviours)
                    behaviour.Attach(me);
            }
        }
    }
}
