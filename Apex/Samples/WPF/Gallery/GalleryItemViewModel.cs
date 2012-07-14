using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace Gallery
{
    public class GalleryItemViewModel : ViewModel
    {
        
        /// <summary>
        /// The NotifyingProperty for the Title property.
        /// </summary>
        private readonly NotifyingProperty TitleProperty =
          new NotifyingProperty("Title", typeof(string), default(string));

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        /// <value>The value of Title.</value>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
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
        /// The PropertyName observable collection.
        /// </summary>
        private ObservableCollection<GalleryItemViewModel> PropertyNameProperty =
          new ObservableCollection<GalleryItemViewModel>();

        /// <summary>
        /// Gets the PropertyName observable collection.
        /// </summary>
        /// <value>The PropertyName observable collection.</value>
        public ObservableCollection<GalleryItemViewModel> PropertyName
        {
            get { return PropertyNameProperty; }
        }
    }
}
