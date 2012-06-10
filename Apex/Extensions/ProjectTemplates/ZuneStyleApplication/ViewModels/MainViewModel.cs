using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ZuneStyleApplication.ViewModels
{
    /// <summary>
    /// The MainViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class MainViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            //  Set the title.
            Title = "ZUNE";

            //  Create the child page view models.
            CollectionViewModel = new CollectionViewModel();

            //  Add the child page view models.
            Pages.Add(CollectionViewModel);

            //  Add some empty pages.
            Pages.Add(new PageViewModel() { Title = "marketplace" });
            Pages.Add(new PageViewModel() { Title = "social" });
        }

        /// <summary>
        /// Gets the collection view model.
        /// </summary>
        public CollectionViewModel CollectionViewModel
        {
            get;
            private set;
        }


    }
}
