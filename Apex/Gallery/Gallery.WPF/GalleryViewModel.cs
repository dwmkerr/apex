using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;
using Gallery.Behaviours;
using Gallery.Controls;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.MultiBorder;
using Gallery.Controls.PaddedGrid;
using Gallery.Controls.TabbedDocumentInterface;
using Gallery.Converters;
using Gallery.CueTextBox;
using Gallery.DragAndDrop;
using Gallery.MVVM;
using Gallery.MVVM.CommandingSample;
using Gallery.MVVM.SimpleSample;
using Gallery.MVVM.ViewBrokerActivationSample;
using Gallery.MVVM.ViewBrokerSample;
using Gallery.PathTextBox;
using Gallery.PivotControl;
using Gallery.Popups;
using Gallery.SearchTextBox;
using Gallery.Behaviours.ListViewItemContextMenuBehaviour;
using Gallery.DragAndDrop.CanvasSample;
using Gallery.DragAndDrop.ItemsControlSample;

namespace Gallery
{
    public class GalleryViewModel : ViewModel
    {
        public GalleryViewModel()
        {
            var home = new Home.HomeViewModel();
            GalleryItems.Add(home);

            var controlItems = new ControlsViewModel();
            GalleryItems.Add(controlItems);

            var converters = new ConvertersViewModel();
            GalleryItems.Add(converters);

            var popupItems = new PopupsViewModel();
            GalleryItems.Add(popupItems);

            var behaviourItems = new BehavioursViewModel();
            GalleryItems.Add(behaviourItems);

            var dragAndDropItems = new DragAndDropViewModel();
            GalleryItems.Add(dragAndDropItems);

            var mvvmItems = new MVVMViewModel();
            GalleryItems.Add(mvvmItems);

            SelectedGalleryItem = home;
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
