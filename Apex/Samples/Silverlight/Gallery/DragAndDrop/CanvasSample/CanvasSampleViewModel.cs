using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace Gallery.DragAndDrop.CanvasSample
{
    /// <summary>
    /// The CanvasSampleViewModel ViewModel class.
    /// </summary>
    public class CanvasSampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasSampleViewModel"/> class.
        /// </summary>
        public CanvasSampleViewModel()
        {
            Title = "Canvas Sample";
        }
    }
}
