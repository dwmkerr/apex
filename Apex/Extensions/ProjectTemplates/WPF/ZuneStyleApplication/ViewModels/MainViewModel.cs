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
            Title = "Zune";

            //  Create a view model for each page.
            var homeViewModel = new PageViewModel() { IsSelected = true, Title = "Home" };
            homeViewModel.Pages.Add(new HomeViewModel() { IsSelected = true});
            var collectionViewModel = new PageViewModel() { Title = "Collection" };
            collectionViewModel.Pages.Add(new MusicViewModel() { IsSelected = true });
            collectionViewModel.Pages.Add(new PicturesViewModel());
            var marketplaceViewModel = new PageViewModel() { Title = "Marketplace" };
            var socialViewModel = new PageViewModel() { Title = "Social" };

            //  Add the child page view models.

            //  Add some empty pages.
            Pages.Add(homeViewModel);
            Pages.Add(collectionViewModel);
            Pages.Add(marketplaceViewModel);
            Pages.Add(socialViewModel);
        }
    }
}
