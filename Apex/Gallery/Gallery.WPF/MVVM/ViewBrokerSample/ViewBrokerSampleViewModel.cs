using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerSample
{
    /// <summary>
    /// The ViewBrokerSampleViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class ViewBrokerSampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBrokerSampleViewModel"/> class.
        /// </summary>
        public ViewBrokerSampleViewModel()
        {
            Title = "View Broker Sample";

            //  Create some devices.
            var docs = new FolderViewModel() { Name = "Documents", Description = "The documents folder.", Files = new ObservableCollection<FileViewModel>() };
            docs.Files.Add(new FileViewModel() { Name = "Accounts", Description = "Accounts for 2012." } );
            docs.Files.Add(new FileViewModel() { Name = "Clients", Description = "List of clients."});
            docs.Files.Add(new FileViewModel() { Name = "Company Logo", Description = "Latest company logo, suitable for print." });
            folders.Add(docs);
        }
        
        private NotifyingProperty SelectedItemProperty =
          new NotifyingProperty("SelectedItem", typeof(object), default(object));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
                

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<FolderViewModel> folders =
            new ObservableCollection<FolderViewModel>();

        /// <summary>
        /// Gets the devices.
        /// </summary>
        public ObservableCollection<FolderViewModel> Folders
        {
            get { return folders; }
        }

    }
}
