using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ApexWizards.ViewAndViewModelWizard
{
    /// <summary>
    /// The ViewAndViewModelWizardViewModel is the view model
    /// for the ViewAndViewModelWizardView.
    /// </summary>
    public class ViewAndViewModelWizardViewModel : ViewModel
    {
        /// <summary>
        /// Views the model wizard view model.
        /// </summary>
        public ViewAndViewModelWizardViewModel()
        {
            OKCommand = new Command(DoOKCommand, true);
        }

        /// <summary>
        /// Does the OK command.
        /// </summary>
        private void DoOKCommand()
        {
        }

        /// <summary>
        /// The Base Name notifying property.
        /// </summary>
        private NotifyingProperty BaseNameProperty =
          new NotifyingProperty("BaseName", typeof(string), default(string));

        /// <summary>
        /// Gets or sets the name of the view model.
        /// </summary>
        /// <value>
        /// The name of the view model.
        /// </value>
        public string BaseNameName
        {
            get { return (string)GetValue(BaseNameProperty); }
            set { SetValue(BaseNameProperty, value); }
        }

        /// <summary>
        /// The Base Name notifying property.
        /// </summary>
        private NotifyingProperty ViewNameProperty =
          new NotifyingProperty("ViewName", typeof(string), default(string));

        /// <summary>
        /// Gets or sets the name of the view model.
        /// </summary>
        /// <value>
        /// The name of the view model.
        /// </value>
        public string ViewNameName
        {
            get { return (string)GetValue(ViewNameProperty); }
            set { SetValue(ViewNameProperty, value); }
        }

        /// <summary>
        /// The Base Name notifying property.
        /// </summary>
        private NotifyingProperty ViewModelNameProperty =
          new NotifyingProperty("ViewModelName", typeof(string), default(string));

        /// <summary>
        /// Gets or sets the name of the view model.
        /// </summary>
        /// <value>
        /// The name of the view model.
        /// </value>
        public string ViewModelNameName
        {
            get { return (string)GetValue(ViewModelNameProperty); }
            set { SetValue(ViewModelNameProperty, value); }
        }

        /// <summary>
        /// Gets the OK command.
        /// </summary>
        public Command OKCommand
        {
            get;
            private set;
        }                
    }
}
