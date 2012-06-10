using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Apex.MVVM;

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

        /// <summary>
        /// Called when the <see cref="P:System.Windows.Controls.ItemsControl.ItemsSource"/> property changes.
        /// </summary>
        /// <param name="oldValue">Old value of the <see cref="P:System.Windows.Controls.ItemsControl.ItemsSource"/> property.</param>
        /// <param name="newValue">New value of the <see cref="P:System.Windows.Controls.ItemsControl.ItemsSource"/> property.</param>
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            //  Call the base.
            base.OnItemsSourceChanged(oldValue, newValue);

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
                DoSelectItemCommand(itemToSelect);
        }

        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //  Call the base.
            base.OnItemsChanged(e);

            //  Check for selected items.
            ISelectableItem itemToSelect = null;
            if (ItemsSource != null)
            {
                foreach (var newItem in ItemsSource)
                {
                    if (newItem is ISelectableItem && ((ISelectableItem)newItem).IsSelected)
                        itemToSelect = (ISelectableItem)newItem;
                }
            }

            //  Select the item to select (if there is one).
            if (itemToSelect != null)
                DoSelectItemCommand(itemToSelect);
        }

        /// <summary>
        /// The DependencyProperty for the SelectedItem property.
        /// </summary>
        private static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectableItemsControl),
            new FrameworkPropertyMetadata(default(object), 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnSelectedItemChanged)));

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
        /// Called when SelectedItem is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSelectedItemChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            SelectableItemsControl me = o as SelectableItemsControl;
        }

        /// <summary>
        /// Performs the SelectItem command.
        /// </summary>
        /// <param name="parameter">The SelectItem command parameter.</param>
        private void DoSelectItemCommand(object itemToSelect)
        {
            //  Go through every item in the items source.
            foreach (var item in ItemsSource)
            {
                //  Is this the selected item?
                bool isSelected = item == itemToSelect;

                //  If this is the selected item, store it.
                if (isSelected)
                    SelectedItem = item;
                
                //  Is the item an ISelectableItem?
                var selectableItem = item as ISelectableItem;
                if (selectableItem != null)
                {
                    //  The item implements ISelectableItem, meaning that we 
                    //  can keep it fully up-to-date on it's selection status.

                    //  Do we need to deselect it?
                    if (selectableItem.IsSelected && isSelected == false)
                    {
                        //  Deselect the item.
                        selectableItem.OnDeselected();
                        selectableItem.IsSelected = false;
                    }

                    //  Do we need to select it?
                    if (selectableItem.IsSelected == false && isSelected)
                    {
                        //  Select the item.
                        selectableItem.OnSelected();
                        selectableItem.IsSelected = true;
                    }
                }
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
