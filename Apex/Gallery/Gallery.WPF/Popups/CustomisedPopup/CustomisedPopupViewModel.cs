using Apex.MVVM;

namespace Gallery.Popups.CustomisedPopup
{
    public class CustomisedPopupViewModel : GalleryItemViewModel
    {
        public CustomisedPopupViewModel()
        {
            Title = "Customised Popup";

            //  Create the ShowPopup Command.
            ShowPopupCommand = new Command(DoShowPopupCommand);
        }

        
        /// <summary>
        /// The NotifyingProperty for the PopupResult property.
        /// </summary>
        private readonly NotifyingProperty PopupResultProperty =
          new NotifyingProperty("PopupResult", typeof(object), default(object));

        /// <summary>
        /// Gets or sets PopupResult.
        /// </summary>
        /// <value>The value of PopupResult.</value>
        public object PopupResult
        {
            get { return (object)GetValue(PopupResultProperty); }
            set { SetValue(PopupResultProperty, value); }
        }

        /// <summary>
        /// Performs the ShowPopup command.
        /// </summary>
        /// <param name="parameter">The ShowPopup command parameter.</param>
        private void DoShowPopupCommand(object parameter)
        {
        }

        /// <summary>
        /// Gets the ShowPopup command.
        /// </summary>
        /// <value>The value of .</value>
        public Command ShowPopupCommand
        {
            get;
            private set;
        }
    }
}
