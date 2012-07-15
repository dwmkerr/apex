
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
            base.OnAttached();
        }

        private void WireContextMenu()
        {

            //  Get the associated list view.
            var listView = AssociatedObject as ListView;

            //  If we have the listview, wait for the right mouse click.
            if (listView != null)
                listView.MouseRightButtonUp += listView_MouseRightButtonUp;
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
            var me = o as ListViewItemContextMenuBehaviour;
            me.WireContextMenu();
        }

        private void listView_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
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
