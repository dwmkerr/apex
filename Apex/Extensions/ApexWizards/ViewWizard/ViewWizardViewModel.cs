using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ApexWizards.ViewWizard
{
    /// <summary>
    /// The View Wizard View Model.
    /// </summary>
    public class ViewWizardViewModel : ViewModel
    {
        public ViewWizardViewModel()
        {
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

        
        private NotifyingProperty ViewNameProperty =
          new NotifyingProperty("ViewName", typeof(string), default(string));

        public string ViewName
        {
            get { return (string)GetValue(ViewNameProperty); }
            set { SetValue(ViewNameProperty, value); }
        }
                

        
        private NotifyingProperty ViewModelTypeProperty =
          new NotifyingProperty("ViewModelType", typeof(string), default(string));

        public string ViewModelType
        {
            get { return (string)GetValue(ViewModelTypeProperty); }
            set { SetValue(ViewModelTypeProperty, value); }
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
