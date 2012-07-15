
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Apex.Extensions;

namespace Apex.Behaviours
{
    /// <summary>
    /// The ListViewItemContextMenuBehaviour allows a context menu to be associated
    /// with an entire row for a ListView with a GridView style. The context
    /// menu automatically has its DataContext set to the DataContext of the item.
    /// </summary>
    public class ListViewItemContextMenuBehaviour : Behavior<ListView>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            //  Call the base.
            base.OnAttached();

            //  Wire up the context menu.
            WireUpContextMenu();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            //  Unwire the context menu.
            UnWireContextMenu();

            //  Call the base.
            base.OnDetaching();
        }

        /// <summary>
        /// Wires up the context menu.
        /// </summary>
        private void WireUpContextMenu()
        {
            //  If we have the listview, wait for the right mouse click.
            if (AssociatedObject != null)
                AssociatedObject.MouseRightButtonUp += listView_MouseRightButtonUp;
        }

        /// <summary>
        /// Unwires context menu.
        /// </summary>
        private void UnWireContextMenu()
        {
            //  If we have the listview, remove the event handler.
            if (AssociatedObject != null)
                AssociatedObject.MouseRightButtonUp -= listView_MouseRightButtonUp;
        }

        
        /// <summary>
        /// The DependencyProperty for the ContextMenu property.
        /// </summary>
        public static readonly DependencyProperty ContextMenuProperty =
          DependencyProperty.Register("ContextMenu", typeof(ContextMenu), typeof(ListViewItemContextMenuBehaviour),
          new PropertyMetadata(default(ContextMenu), new PropertyChangedCallback(OnContextMenuChanged)));

        /// <summary>
        /// Gets or sets ContextMenu.
        /// </summary>
        /// <value>The value of ContextMenu.</value>
        public ContextMenu ContextMenu
        {
            get { return (ContextMenu)GetValue(ContextMenuProperty); }
            set { SetValue(ContextMenuProperty, value); }
        }

        /// <summary>
        /// Called when ContextMenu is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnContextMenuChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Get the behaviour.
            var me = o as ListViewItemContextMenuBehaviour;

            //  Wire up the context menu.
            me.WireUpContextMenu();
        }

        /// <summary>
        /// Handles the MouseRightButtonUp event of the listView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void listView_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //  Make sure we have a dependency object.
            var originalDependencyObject = e.OriginalSource as DependencyObject;
            if (originalDependencyObject == null)
                return;

            //  Get the parent list view item.
            var listViewItem = originalDependencyObject.GetParent<ListViewItem>();

            //  If we don't have one, bail.
            if (listViewItem == null)
                return;

            //  Show the context menu.
            if (ContextMenu != null)
            {
                ContextMenu.DataContext = listViewItem.DataContext;
                ContextMenu.PlacementTarget = listViewItem;
                ContextMenu.IsOpen = true;
            }
        }
    }
}
