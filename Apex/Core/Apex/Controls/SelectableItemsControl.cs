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



#if SILVERLIGHT

            //  Listen for the items source changed.
           RegisterForNotification("ItemsSource", this, new PropertyChangedCallback(OnItemsSourceChanged));
#endif
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //  If we have an items source source, we should set the selected value (if there is one).
            CheckNewItemsSourceForSelectedItem(ItemsSource);

        }

#if SILVERLIGHT

        /// Listen for change of the dependency property TODO move into a helper class.
        public void RegisterForNotification(string propertyName, FrameworkElement element, PropertyChangedCallback callback)
        {

            //Bind to a depedency property
            Binding b = new Binding(propertyName) { Source = element };
            var prop = System.Windows.DependencyProperty.RegisterAttached(
                "ListenAttached" + propertyName,
                typeof(object),
                typeof(ItemsControl),
                new System.Windows.PropertyMetadata(callback));

            element.SetBinding(prop, b);
        }

        private void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {   
            //  Get the items.
            CheckNewItemsSourceForSelectedItem(e.NewValue as IEnumerable);
        }

#else

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

#endif

        private void CheckNewItemsSourceForSelectedItem(IEnumerable newItemsSource)
        {
            if (newItemsSource == null)
                return;
            //  Do we have an item to select?
            var itemToSelect = (from object i in newItemsSource
                                where i is ISelectableItem && ((ISelectableItem)i).IsSelected
                                select i as ISelectableItem).FirstOrDefault();


            //  Select the item to select (if there is one).
            if (itemToSelect != null)
                InternalSelectItem(itemToSelect, newItemsSource);
        }

        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //  Call the base.
            base.OnItemsChanged(e);

            //  Do we have an item to select?
            var selectedItem = (from object i in ItemsSource
                           where i is ISelectableItem && ((ISelectableItem)i).IsSelected
                           select i as ISelectableItem).FirstOrDefault();

            //  Select the item to select (if there is one).
            if (selectedItem != null)
                InternalSelectItem(selectedItem, ItemsSource);
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
        }

        /// <summary>
        /// Used internally to select the item, even if it is not in the current itemsource.
        /// This tidies things up because in the Silverlight version we have to do a bit more
        /// manual work and call this function.
        /// </summary>
        /// <param name="itemToSelect">The item to select.</param>
        /// <param name="itemsSource">The items source.</param>
        private void InternalSelectItem(object itemToSelect, IEnumerable itemsSource)
        {
            //  Handle the trivial case.
            if (SelectedItem == itemToSelect)
                return;

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
