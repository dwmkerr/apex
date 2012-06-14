using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ZuneStyleApplication.ViewModels
{
    /// <summary>
    /// The CollectionViewModel ViewModel class.
    /// </summary>
    public class CollectionViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionViewModel"/> class.
        /// </summary>
        public CollectionViewModel()
        {
            Title = "collection";

            //  Create the child pages.
            MusicViewModel = new ViewModels.MusicViewModel();
            PicturesViewModel = new ViewModels.PicturesViewModel();

            //  Add the child pages.
            Pages.Add(MusicViewModel);
            Pages.Add(PicturesViewModel);
        }

        /// <summary>
        /// Gets the music view model.
        /// </summary>
        public MusicViewModel MusicViewModel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the pictures view model.
        /// </summary>
        public PicturesViewModel PicturesViewModel
        {
            get;
            private set;
        }
    }
}
