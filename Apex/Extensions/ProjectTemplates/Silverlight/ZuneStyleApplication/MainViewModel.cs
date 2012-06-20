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

        /// <summary>
        /// The active sub page notifying property.
        /// </summary>
        private readonly NotifyingProperty ActiveSubPageProperty = new NotifyingProperty("ActiveSubPage", typeof(PageViewModel), null);

        /// <summary>
        /// Gets or sets the active sub page.
        /// </summary>
        /// <value>
        /// The active sub page.
        /// </value>
        public PageViewModel ActiveSubPage
        {
            get { return (PageViewModel) GetValue(ActiveSubPageProperty); }
            set { SetValue(ActiveSubPageProperty, value); }
        }
    }
}
