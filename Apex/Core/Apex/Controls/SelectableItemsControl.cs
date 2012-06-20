using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Apex.MVVM;
using Apex.Extensions;
using System.Windows.Data;
using System.Collections;

namespace Apex.Controls
{
    /// <summary>
    /// An ISelectableItem will automatically have its OnSelected/OnDeselected
    /// functions called and its IsSelected property set if the items are used
    /// in a SelectableItemsControl.
    /// </summary>
    public interface ISelectableItem
    {
        void OnSelected();
        void OnDeselected();
        bool IsSelected { get; set; }
    }

    /// <summary>
    /// A SelectableItemsControl is a standard ItemsControl that
    /// can flag an item as selected.
    /// TODO: Should this be limited to ISelectableItem items? 
    /// With ISelectable.IsSelected, ISelectable.Activate, ISelectable.Deactivate?
    /// </summary>
    public class SelectableItemsControl : ItemsControl
    {
        public SelectableItemsControl()
        {
            //  Wire up commands.
            SelectItemCommand = new Command(DoSelectItemCommand);

            Binding binding = new Binding("ItemsSource") {Source = this};
            SetBinding(dp, binding);
        }


        static readonly DependencyProperty dp = DependencyProperty.RegisterAttached("ItemsSourceProxy", typeof (IEnumerable),
                                                         typeof (SelectableItemsControl),
                                                         new PropertyMetadata(null,
                                                                              new PropertyChangedCallback(
                                                                                  OnItemsSourceProxyChanged)));

        private static void OnItemsSourceProxyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = d as SelectableItemsControl;
            me.CheckNewItemsSourceForSelectedItem(e.NewValue as IEnumerable, true);

            me.DoFudge();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //  If we have an items source source, we should set the selected value (if there is one).
            CheckNewItemsSourceForSelectedItem(ItemsSource, true);

            DoFudge();

        }

        private void CheckNewItemsSourceForSelectedItem(IEnumerable newItemsSource, bool forceNotify)
        {
            if (newItemsSource == null)
                return;
            //  Do we have an item to select?
            var itemToSelect = (from object i in newItemsSource
                                where i is ISelectableItem && ((ISelectableItem)i).IsSelected
                                select i as ISelectableItem).FirstOrDefault();


            //  Select the item to select (if there is one).
            if (itemToSelect != null)
                InternalSelectItem(itemToSelect, newItemsSource, forceNotify);
        }


        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            //  Do we have an item to select?
            var selectedItem = (from object i in ItemsSource
                                where i is ISelectableItem && ((ISelectableItem)i).IsSelected
                                select i as ISelectableItem).FirstOrDefault();

            System.Diagnostics.Debug.WriteLine(Name + ": ItemsChanged, " + (SelectedItem == null ? "null" : SelectedItem.GetType().Name) +
                " -> " + (selectedItem == null ? "null" : selectedItem.GetType().Name));

            //  Select the item to select (if there is one).
            if (selectedItem != null)
                InternalSelectItem(selectedItem, ItemsSource);

            DoFudge();
        }

        /// <summary>
        /// The DependencyProperty for the SelectedItem property.
        /// </summary>
        private static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectableItemsControl),
            new FrameworkPropertyMetadata(default(object), 
#if !SILVERLIGHT
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectedItemChanged)));
#else
 FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(SelectedItemChanged)));
#endif

        private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue == null)
                System.Diagnostics.Debug.WriteLine("NULL");
            var me = d as SelectableItemsControl;
            System.Diagnostics.Debug.WriteLine(me.Name + ": " + (e.OldValue == null ? "null" : e.OldValue.GetType().Name) +
                " -> " + (e.NewValue == null ? "null" : e.NewValue.GetType().Name));



            me.DoFudge();
        }
       


        /// <summary>
        /// Gets or sets SelectedItem.
        /// </summary>
        /// <value>The value of SelectedItem.</value>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Performs the SelectItem command.
        /// </summary>
        /// <param name="itemToSelect">The item to select.</param>
        private void DoSelectItemCommand(object itemToSelect)
        {
            //  Use the internal function for this for consistency.
            InternalSelectItem(itemToSelect, ItemsSource);

            DoFudge();
        }

        private IEnumerable fudgeFactor = null;
        private void DoFudge()
        {
            if (ItemsSource != fudgeFactor && fudgeFactor != null)
                CheckNewItemsSourceForSelectedItem(ItemsSource, true);
            fudgeFactor = ItemsSource;
        }

        /// <summary>
        /// Used internally to select the item, even if it is not in the current itemsource.
        /// This tidies things up because in the Silverlight version we have to do a bit more
        /// manual work and call this function.
        /// </summary>
        /// <param name="itemToSelect">The item to select.</param>
        /// <param name="itemsSource">The items source.</param>
        private void InternalSelectItem(object itemToSelect, IEnumerable itemsSource, bool forceNotify = false)
        {
            //  Handle the trivial case.
            if (SelectedItem == itemToSelect && !forceNotify)
                return;

            System.Diagnostics.Debug.WriteLine(Name + ": InternalSelectItem, " + (SelectedItem == null ? "null" : SelectedItem.GetType().Name) +
                " -> " + (itemToSelect == null ? "null" : itemToSelect.GetType().Name));

            //  Deactivate the old item.
            var oldItem = (from object i in itemsSource
                          where i is ISelectableItem && ((ISelectableItem) i).IsSelected
                          select i as ISelectableItem).FirstOrDefault();
            if(oldItem != null)
            {
                oldItem.IsSelected = false;
                oldItem.OnDeselected();
            }

            //  Activate the new item.
            SelectedItem = itemToSelect;
            if(itemToSelect is ISelectableItem)
            {
                ((ISelectableItem)itemToSelect).IsSelected = true;
                ((ISelectableItem)itemToSelect).OnSelected();
            }
        }

        /// <summary>
        /// Gets the SelectItem command.
        /// </summary>
        /// <value>The SelectItem command.</value>
        public Command SelectItemCommand
        {
            get;
            private set;
        }
                
    }
}
