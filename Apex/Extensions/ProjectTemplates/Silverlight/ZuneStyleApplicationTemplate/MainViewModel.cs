using Apex.MVVM;
using $safeprojectname$.Pages;
using $safeprojectname$.Pages.Apex;
using $safeprojectname$.Pages.TheModel;
using $safeprojectname$.Pages.ThePages;
using $safeprojectname$.Pages.TheShell;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$
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
            var homeViewModel = new PageViewModel()
            {
                IsSelected = true, Title = "Home"
            };

            //  Add home pages.
            homeViewModel.Pages.Add(new ApexViewModel() { IsSelected = true });
            homeViewModel.Pages.Add(new TheShellViewModel());
            homeViewModel.Pages.Add(new TheModelViewModel());
            homeViewModel.Pages.Add(new ThePagesViewModel());

            //  Create the 'collection' section.
            var collectionViewModel = new PageViewModel() {Title = "Collection"};

            //  Add the collection pages.
            collectionViewModel.Pages.Add(new MusicViewModel() { IsSelected = true });
            collectionViewModel.Pages.Add(new PicturesViewModel());

            //  Add the page groups to the view model.
            Pages.Add(homeViewModel);
            Pages.Add(collectionViewModel);
        }
    }
}
