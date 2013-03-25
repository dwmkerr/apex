using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;
using Gallery.DragAndDrop.CanvasSample;
using Gallery.DragAndDrop.ItemsControlSample;
using Gallery.MVVM.CommandingSample;
using Gallery.MVVM.SimpleSample;
using Gallery.MVVM.ViewBrokerActivationSample;
using Gallery.MVVM.ViewBrokerSample;
using Gallery.Popups;

//using Gallery.PathTextBox;
//using Gallery.PivotControl;
//using Gallery.Popups;
//using Gallery.SearchTextBox;
//using Gallery.Behaviours.ListViewItemContextMenuBehaviour;
//using Gallery.DragAndDrop.CanvasSample;
//using Gallery.DragAndDrop.ItemsControlSample;

namespace Gallery
{
    public class GalleryViewModel : ViewModel
    {
        public GalleryViewModel()
        {
            var homeItem = new Home.HomeViewModel();
            GalleryItems.Add(homeItem);
            /*
            var controlItems = new GalleryItemViewModel() {Title = "Controls"};
            controlItems.GalleryItems.Add(new ApexGridViewModel());
            controlItems.GalleryItems.Add(new CueTextBoxViewModel());
            //controlItems.GalleryItems.Add(new CrossButtonViewModel());
            //controlItems.GalleryItems.Add(new EnumComboBoxViewModel());
            //controlItems.GalleryItems.Add(new MultiBorderViewModel());
            controlItems.GalleryItems.Add(new PaddedGridViewModel());
            //controlItems.GalleryItems.Add(new PathTextBoxViewModel());
            //controlItems.GalleryItems.Add(new PivotControlViewModel());
            //controlItems.GalleryItems.Add(new SearchTextBoxViewModel());
            GalleryItems.Add(controlItems);
            */
            var popupItems = new GalleryItemViewModel() {Title = "Popups"};
            popupItems.GalleryItems.Add(new PopupsViewModel());
            GalleryItems.Add(popupItems);

            //var behaviourItems = new GalleryItemViewModel() {Title = "Behaviours"};
            //behaviourItems.GalleryItems.Add(new ListViewItemContextMenuBehaviourViewModel());
            //GalleryItems.Add(behaviourItems);

            var dragAndDropItems = new GalleryItemViewModel() { Title = "Drag and Drop" };
            dragAndDropItems.GalleryItems.Add(new CanvasSampleViewModel());
            dragAndDropItems.GalleryItems.Add(new ItemsControlSampleViewModel());
            GalleryItems.Add(dragAndDropItems);

            var mvvmItems = new GalleryItemViewModel() { Title = "MVVM" };
            mvvmItems.GalleryItems.Add(new SimpleExampleViewModel());
            mvvmItems.GalleryItems.Add(new CommandingSampleViewModel());
            mvvmItems.GalleryItems.Add(new ViewBrokerSampleViewModel());
            mvvmItems.GalleryItems.Add(new ViewBrokerActivationSampleViewModel());
            GalleryItems.Add(mvvmItems);
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
