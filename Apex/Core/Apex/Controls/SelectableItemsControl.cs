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
        /// <summary>
        /// Called when selected.
        /// </summary>
        void OnSelected();

        /// <summary>
        /// Called when deselected.
        ///  </summary>
        void OnDeselected();

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        bool IsSelected { get; set; }
    }

    internal class SelectableItemsControlItem : ContentControl
    {
        /// <summary>
        /// The DependencyProperty for the IsSelected property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
          DependencyProperty.Register("IsSelected", typeof(bool), typeof(SelectableItemsControlItem),
          new PropertyMetadata(default(bool), new PropertyChangedCallback(OnIsSelectedChanged)));

        /// <summary>
        /// Gets or sets IsSelected.
        /// </summary>
        /// <value>The value of IsSelected.</value>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        /// <summary>
        /// Called when IsSelected is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            SelectableItemsControlItem me = o as SelectableItemsControlItem;

#if SILVERLIGHT
            if(args.OldValue != args.NewValue)
            VisualStateManager.GoToState(me, ((bool)args.NewValue) ? "Selected" : "Unselected", true);
#endif
        }
    }

    /// <summary>
    /// A SelectableItemsControl is a standard ItemsControl that
    /// can flag an item as selected.
    /// TODO: Should this be limited to ISelectableItem items? 
    /// With ISelectable.IsSelected, ISelectable.Activate, ISelectable.Deactivate?
    /// </summary>
    public class SelectableItemsControl : ItemsControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectableItemsControl"/> class.
        /// </summary>
        public SelectableItemsControl()
        {
            //  Wire up commands.
            SelectItemCommand = new Command(DoSelectItemCommand);

            Binding binding = new Binding("ItemsSource") {Source = this};
            SetBinding(dp, binding);
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is SelectableItemsControlItem);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SelectableItemsControlItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            ((SelectableItemsControlItem)element).ContentTemplate = ItemTemplate;
            ((SelectableItemsControlItem)element).Content = item;

            if (ClickToSelectItem && item is ISelectableItem)
                ((SelectableItemsControlItem) element).MouseLeftButtonDown += (sender, args) => DoSelectItemCommand(item);
        }

        /// <summary>
        /// ItemsSourceProxy.
        /// </summary>
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

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
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


        /// <summary>
        /// Invoked when the <see cref="P:System.Windows.Controls.ItemsControl.Items"/> property changes.
        /// </summary>
        /// <param name="e">Information about the change.</param>
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
        /// <param name="forceNotify">if set to <c>true</c> [force notify].</param>
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
                var oldItemContainer = GetItemContainerFromItem(oldItem);
                if (oldItemContainer != null)
                    oldItemContainer.IsSelected = false;
            }

            //  Activate the new item.
            SelectedItem = itemToSelect;
            if(itemToSelect is ISelectableItem)
            {
                ((ISelectableItem)itemToSelect).IsSelected = true;
                ((ISelectableItem)itemToSelect).OnSelected();
                var itemContainer = GetItemContainerFromItem(itemToSelect);
                if (itemContainer != null)
                    itemContainer.IsSelected = true;
            }
        }

        private SelectableItemsControlItem GetItemContainerFromItem(object item)
        {
            return Items.OfType<SelectableItemsControlItem>().FirstOrDefault(sici => sici.Content == item);
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

        
        /// <summary>
        /// The DependencyProperty for the ClickToSelectItem property.
        /// </summary>
        public static readonly DependencyProperty ClickToSelectItemProperty =
          DependencyProperty.Register("ClickToSelectItem", typeof(bool), typeof(SelectableItemsControl),
          new PropertyMetadata(default(bool)));

        /// <summary>
        /// Gets or sets ClickToSelectItem.
        /// </summary>
        /// <value>The value of ClickToSelectItem.</value>
        public bool ClickToSelectItem
        {
            get { return (bool)GetValue(ClickToSelectItemProperty); }
            set { SetValue(ClickToSelectItemProperty, value); }
        }
    }
}
