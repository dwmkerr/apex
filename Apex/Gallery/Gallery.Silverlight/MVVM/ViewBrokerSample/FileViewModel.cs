using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerSample
{
    /// <summary>
    /// The ComponentViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class FileViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileViewModel"/> class.
        /// </summary>
        public FileViewModel()
        {
        }
        
        /// <summary>
        /// The name property.
        /// </summary>
        private NotifyingProperty NameProperty =
          new NotifyingProperty("Name", typeof(string), default(string));

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        private NotifyingProperty DescriptionProperty =
          new NotifyingProperty("Description", typeof(string), default(string));

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }            
    }
}
