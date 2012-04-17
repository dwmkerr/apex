using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerSample
{
    /// <summary>
    /// The DeviceViewModel ViewModel class.
    /// </summary>
    public class FolderViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderViewModel"/> class.
        /// </summary>
        public FolderViewModel()
        {
        }

        
        private NotifyingProperty NameProperty =
          new NotifyingProperty("Name", typeof(string), default(string));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        
        private NotifyingProperty DescriptionProperty =
          new NotifyingProperty("Description", typeof(string), default(string));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }                     

        /// <summary>
        /// The components.
        /// </summary>
        private ObservableCollection<FileViewModel> files = 
            new ObservableCollection<FileViewModel>();

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        public ObservableCollection<FileViewModel> Files
        {
            get;
            set;
        }
    }
}
