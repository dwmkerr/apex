using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.MultiBorder;
using Gallery.Controls.PaddedGrid;
using Gallery.CueTextBox;
using Gallery.PivotControl;
using Gallery.Popups;
using Gallery.SearchTextBox;

namespace Gallery
{
    public class GalleryViewModel : ViewModel
    {
        public GalleryViewModel()
        {
            var controlItems = new GalleryItemViewModel() {Title = "Controls"};
            controlItems.GalleryItems.Add(new ApexGridViewModel());
            controlItems.GalleryItems.Add(new CueTextBoxViewModel());
            controlItems.GalleryItems.Add(new CrossButtonViewModel());
            controlItems.GalleryItems.Add(new EnumComboBoxViewModel());
            controlItems.GalleryItems.Add(new MultiBorderViewModel());
            controlItems.GalleryItems.Add(new PaddedGridViewModel());
            controlItems.GalleryItems.Add(new PivotControlViewModel());
            controlItems.GalleryItems.Add(new SearchTextBoxViewModel());
            GalleryItems.Add(controlItems);

            var popupItems = new GalleryItemViewModel() {Title = "Popups"};
            popupItems.GalleryItems.Add(new PopupsViewModel());
            GalleryItems.Add(popupItems);

            var behaviourItems = new GalleryItemViewModel() {Title = "Behaviours"};
        }

        /// <summary>
        /// The GalleryItems observable collection.
        /// </summary>
        private ObservableCollection<GalleryItemViewModel> GalleryItemsProperty =
            new ObservableCollection<GalleryItemViewModel>();

        /// <summary>
        /// Gets the GalleryItems observable collection.
        /// </summary>
        /// <value>The GalleryItems observable collection.</value>
        public ObservableCollection<GalleryItemViewModel> GalleryItems
        {
            get { return GalleryItemsProperty; }
        }

        
        /// <summary>
        /// The NotifyingProperty for the SelectedGalleryItem property.
        /// </summary>
        private readonly NotifyingProperty SelectedGalleryItemProperty =
          new NotifyingProperty("SelectedGalleryItem", typeof(GalleryItemViewModel), default(GalleryItemViewModel));

        /// <summary>
        /// Gets or sets SelectedGalleryItem.
        /// </summary>
        /// <value>The value of SelectedGalleryItem.</value>
        public GalleryItemViewModel SelectedGalleryItem
        {
            get { return (GalleryItemViewModel)GetValue(SelectedGalleryItemProperty); }
            set { SetValue(SelectedGalleryItemProperty, value); }
        }
    }

}
