using Apex.MVVM;

namespace WpfSelectionBug
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
            Title = "Test";

            //  Create the pages.
            CreatePages();
        }

        /// <summary>
        /// Creates the pages.
        /// </summary>
        private void CreatePages()
        {
            var page1 = new FruitPageGroupViewModel() {IsSelected = true};
            page1.Pages.Add(new ApplePageViewModel() { IsSelected = true });
            page1.Pages.Add(new PearPageViewModel());
            var page2 = new VegPageGroupViewModel();
            page2.Pages.Add(new OnionPageViewModel() { IsSelected = true });
            page2.Pages.Add(new CarrotPageViewModel());

            //  Add the page groups to the view model.
            Pages.Add(page1);
            Pages.Add(page2);
        }
    }
}
