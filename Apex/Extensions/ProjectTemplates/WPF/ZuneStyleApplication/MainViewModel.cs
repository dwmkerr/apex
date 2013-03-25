using System.Linq;
using Apex.MVVM;
using ZuneStyleApplication.Pages;
using ZuneStyleApplication.Pages.Apex;
using ZuneStyleApplication.Pages.TheModel;
using ZuneStyleApplication.Pages.ThePages;
using ZuneStyleApplication.Pages.TheShell;
using ZuneStyleApplication.ViewModels;

namespace ZuneStyleApplication
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

            //  Create the pages.
            CreatePages();
        }

        /// <summary>
        /// Creates the pages.
        /// </summary>
        private void CreatePages()
        {
            //  Create the 'home' section.
            var homeViewModel = new PageViewModel { Title = "Home" };
            Pages.Add(homeViewModel);
            ActivePage = Pages.FirstOrDefault();

            //  Add home pages.
            homeViewModel.Pages.Add(new ApexViewModel());
            homeViewModel.Pages.Add(new TheShellViewModel());
            homeViewModel.Pages.Add(new TheModelViewModel());
            homeViewModel.Pages.Add(new ThePagesViewModel());
            homeViewModel.ActivePage = homeViewModel.Pages.FirstOrDefault();

            //  Create the 'collection' section.
            var collectionViewModel = new PageViewModel() { Title = "Collection" };
            collectionViewModel.Pages.Add(new MusicViewModel() { IsSelected = true });
            collectionViewModel.Pages.Add(new PicturesViewModel());
            collectionViewModel.ActivePage = collectionViewModel.Pages.FirstOrDefault();
            Pages.Add(collectionViewModel);
        }
    }
}
