using System;
using System.Collections.Generic;
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
        }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //  If we have an items source source, we should set the selected value (if there is one).
            CheckNewItemsSourceForSelectedItem(SelectableItemsSource, true);

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

        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //  Call the base.
            base.OnItemsChanged(e);

            //  Do we have an item to select?
            var selectedItem = (from object i in SelectableItemsSource
                           where i is ISelectableItem && ((ISelectableItem)i).IsSelected
                           select i as ISelectableItem).FirstOrDefault();

            //  Select the item to select (if there is one).
            if (selectedItem != null)
                InternalSelectItem(selectedItem, SelectableItemsSource);
        }

        /// <summary>
        /// The DependencyProperty for the SelectedItem property.
        /// </summary>
        private static readonly DependencyProperty SelectableItemsSourceProperty =
            DependencyProperty.Register("SelectableItemsSource", typeof (IEnumerable), typeof (SelectableItemsControl),
                                        new PropertyMetadata(default(object),
                                                             new PropertyChangedCallback(SelectableItemsSourceChanged)));

        private static void SelectableItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SelectableItemsControl me = d as SelectableItemsControl;
            IEnumerable newValue = e.NewValue as IEnumerable;
            me.ItemsSource = e.NewValue as IEnumerable;

            //  Check for selected items.
            ISelectableItem itemToSelect = null;
            if (newValue != null)
            {
                foreach (var newItem in newValue)
                {
                    if (newItem is ISelectableItem && ((ISelectableItem)newItem).IsSelected)
                        itemToSelect = (ISelectableItem)newItem;
                }
            }

            //  Select the item to select (if there is one).
            if (itemToSelect != null)
                me.DoSelectItemCommand(itemToSelect);
            
        }

        /// <summary>
        /// The DependencyProperty for the SelectedItem property.
        /// </summary>
        private static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectableItemsControl),
            new FrameworkPropertyMetadata(default(object), 
#if !SILVERLIGHT
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
#else
 FrameworkPropertyMetadataOptions.None));
#endif
        /// <summary>
        /// Gets or sets SelectableItemsSource.
        /// </summary>
        /// <value>The value of SelectableItemsSource.</value>
        public IEnumerable SelectableItemsSource
        {
            get { return (IEnumerable)GetValue(SelectableItemsSourceProperty); }
            set { SetValue(SelectableItemsSourceProperty, value); }
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
            InternalSelectItem(itemToSelect, SelectableItemsSource);
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
           // if (SelectedItem == itemToSelect && !forceNotify)
           //     return;

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
