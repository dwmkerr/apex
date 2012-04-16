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
    public class DeviceViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceViewModel"/> class.
        /// </summary>
        public DeviceViewModel()
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

        
        private NotifyingProperty ReleaseDateProperty =
          new NotifyingProperty("ReleaseDate", typeof(DateTime), default(DateTime));

        public DateTime ReleaseDate
        {
            get { return (DateTime)GetValue(ReleaseDateProperty); }
            set { SetValue(ReleaseDateProperty, value); }
        }
                
                
                

        /// <summary>
        /// The components.
        /// </summary>
        private ObservableCollection<ComponentViewModel> components = 
            new ObservableCollection<ComponentViewModel>();

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        public ObservableCollection<ComponentViewModel> Components
        {
            get;
            set;
        }
    }
}
