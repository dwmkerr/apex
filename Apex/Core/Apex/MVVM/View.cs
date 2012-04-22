using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Apex.MVVM
{
    /// <summary>
    /// Container for View attached properties.
    /// </summary>
    public static class View
    {
        /// <summary>
        /// The DependencyProperty for the ViewModel property.
        /// </summary>
        private static readonly DependencyProperty ViewModelProperty =
          DependencyProperty.RegisterAttached("ViewModel", typeof(object), typeof(FrameworkElement),
          new PropertyMetadata(default(object), new PropertyChangedCallback(OnViewModelChanged)));

        /// <summary>
        /// Gets the value of the ViewModel property.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <returns>The value of the ViewModel property.</returns>
        public static object GetViewModel(DependencyObject o)
        {
            return (object)o.GetValue(ViewModelProperty);
        }

        /// <summary>
        /// Sets the value of the ViewModel property.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="value">The value of the ViewModel property.</param>
        public static void SetViewModel(DependencyObject o, object value)
        {
            o.SetValue(ViewModelProperty, value);
        }

        /// <summary>
        /// Called when ViewModel is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnViewModelChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Get the framework element.
            FrameworkElement me = o as FrameworkElement;

            //  Set the data context as the view model.
            me.DataContext = GetViewModel(me);
        }
    }
}
