using System.Collections.ObjectModel;
using System.Linq;
using Apex.MVVM;

namespace Gallery.Controls.SelectableItemsControl
{
    public class SelectableItemsControlViewModel : GalleryItemViewModel
    {
        public SelectableItemsControlViewModel()
        {
            Title = "SelectableItemsControl";

            CreateItems();
            SelectedItem = SelectableItems.FirstOrDefault();
        }

        private void CreateItems()
        {
            SelectableItems.Add(new SelectableItemViewModel
                {
                    Title = "Item 1",
                    Details = "The SelectableItemsControl can be set to automatically select an item when it is clicked, " +
                              "by setting the 'ClickToSelectItem' property to true."
                });
            SelectableItems.Add(new SelectableItemViewModel
                {
                    Title = "Item 2",
                    Details = "In this example, there is a selectable items control along the top that allows " +
                              "items to be selected."
                });
            SelectableItems.Add(new SelectableItemViewModel
                {
                    Title = "Item 3",
                    Details = "If the items that are bound implement ISelectableItem, they will have their " +
                              "'IsSelected' property automatically set, as well as the functions 'OnSelected' and 'OnDeselected' will be called."
                });
        }

        
        /// <summary>
        /// The SelectableItems observable collection.
        /// </summary>
        private readonly ObservableCollection<SelectableItemViewModel> SelectableItemsProperty =
          new ObservableCollection<SelectableItemViewModel>();

        /// <summary>
        /// Gets the SelectableItems observable collection.
        /// </summary>
        /// <value>The SelectableItems observable collection.</value>
        public ObservableCollection<SelectableItemViewModel> SelectableItems
        {
            get { return SelectableItemsProperty; }
        }

        
        /// <summary>
        /// The NotifyingProperty for the SelectedItem property.
        /// </summary>
        private readonly NotifyingProperty SelectedItemProperty =
          new NotifyingProperty("SelectedItem", typeof(SelectableItemViewModel), default(SelectableItemViewModel));

        /// <summary>
        /// Gets or sets SelectedItem.
        /// </summary>
        /// <value>The value of SelectedItem.</value>
        public SelectableItemViewModel SelectedItem
        {
            get { return (SelectableItemViewModel)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}
