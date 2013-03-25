using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Apex.Consistency
{
#if !SILVERLIGHT
    
    //  If we're not using Silverlight, the WPF items control has what we need.
    public class ItemsControl : System.Windows.Controls.ItemsControl {}

#else

    /// <summary>
    /// The ItemsControl provides standard functionality across WPF and Siverlight.
    /// </summary>
    public class ItemsControl : System.Windows.Controls.ItemsControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsControl"/> class.
        /// </summary>
        public ItemsControl()
        {
            //  Wire up the proxy.
            WireupItemsSourceProxy();
        }

        /// <summary>
        /// Wires up the items source proxy.
        /// </summary>
        private void WireupItemsSourceProxy()
        {
            //  Create a binding to the items source.
            var binding = new Binding("ItemsSource") { Source = this };
            
            //  Set the binding of the proxy to the items source. Now when the items source changes, so will
            //  the proxy, meaning we can effectively listen for ItemsSource changed in derived classes.
            SetBinding(ItemsSourceProxyProperty, binding);
        }

        protected virtual void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
        }

        /// <summary>
        /// ItemsSourceProxy.
        /// </summary>
        private static readonly DependencyProperty ItemsSourceProxyProperty = DependencyProperty.RegisterAttached(
            "ItemsSourceProxy", typeof (IEnumerable), typeof (ItemsControl), new PropertyMetadata(null, OnItemsSourceProxyChanged));

        /// <summary>
        /// Called when the items source proxy is changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnItemsSourceProxyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  Get the items control.
            var itemsControl = (ItemsControl) d;

            //  Call the virtual OnChanged function.
            itemsControl.OnItemsSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
        }
    }
#endif
}
