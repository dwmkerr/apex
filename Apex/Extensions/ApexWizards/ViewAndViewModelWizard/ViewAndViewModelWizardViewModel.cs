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
            //  Wire up commands.
            OKCommand = new Command(DoOKCommand);
            CancelCommand = new Command(DoCancelCommand);   
        }

        /// <summary>
        /// Does the OK command.
        /// </summary>
        private void DoOKCommand()
        {
        }

        /// <summary>
        /// Does the cancel command.
        /// </summary>
        private void DoCancelCommand()
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
        public string BaseName
        {
            get { return (string)GetValue(BaseNameProperty); }
            set 
            { 
                SetValue(BaseNameProperty, value); 

                //  Update the names.
                if (BaseName != null)
                {
                    ViewModelName = BaseName + "ViewModel";
                    ViewName = BaseName + "View";
                }
            }
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
        public string ViewName
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
        public string ViewModelName
        {
            get { return (string)GetValue(ViewModelNameProperty); }
            set { SetValue(ViewModelNameProperty, value); }
        }

        private NotifyingProperty ViewCreatesViewModelProperty =
          new NotifyingProperty("ViewCreatesViewModel", typeof(bool), default(bool));

        public bool ViewCreatesViewModel
        {
            get { return (bool)GetValue(ViewCreatesViewModelProperty); }
            set { SetValue(ViewCreatesViewModelProperty, value); }
        }

        /// <summary>
        /// Gets the OK command.
        /// </summary>
        public Command OKCommand { get; private set; }

        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        public Command CancelCommand { get; private set; }
    }
}
