using Apex.MVVM;
namespace MVVMSample
{
    /// <summary>
    /// An example view model that uses our new ViewModel base.
    /// </summary>
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            //  Create the build name command.
            buildNameCommand = new Command(BuildName, false);
        }

        private void BuildName()
        {
            //  Set the full name.
            FullName = FirstName + " " + SecondName;
        }

        /// <summary>
        /// The first name property.
        /// </summary>
        private NotifyingProperty firstNameProperty = 
            new NotifyingProperty("FirstName", typeof(string), string.Empty);

        /// <summary>
        /// The second name property.
        /// </summary>
        private NotifyingProperty secondNameProperty =
            new NotifyingProperty("SecondName", typeof(string), string.Empty);

        /// <summary>
        /// The full name property.
        /// </summary>
        private NotifyingProperty fullNameProperty =
            new NotifyingProperty("FullName", typeof(string), string.Empty);

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get { return (string)GetValue(firstNameProperty); }
            set 
            { 
                SetValue(firstNameProperty, value);
                BuildNameCommand.CanExecute = string.IsNullOrEmpty(FirstName) == false && string.IsNullOrEmpty(SecondName) == false;
            }
        }

        /// <summary>
        /// Gets or sets the second name.
        /// </summary>
        /// <value>The second name.</value>
        public string SecondName
        {
            get { return (string)GetValue(secondNameProperty); }
            set
            {
                SetValue(secondNameProperty, value);
                BuildNameCommand.CanExecute = string.IsNullOrEmpty(FirstName) == false && string.IsNullOrEmpty(SecondName) == false;
            }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get { return (string)GetValue(fullNameProperty); }
            set { SetValue(fullNameProperty, value); }
        }

        /// <summary>
        /// The build name command.
        /// </summary>
        private Command buildNameCommand;

        /// <summary>
        /// Gets the build name command.
        /// </summary>
        /// <value>The build name command.</value>
        public Command BuildNameCommand
        {
            get { return buildNameCommand; }
        }
    }
}
