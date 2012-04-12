using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ApexWizards.ViewWizard
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ViewWizardViewModel : ViewModel
    {
        public ViewWizardViewModel()
        {
            OKCommand = new Command(DoOKCommand, true);
        }

        private void DoOKCommand()
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
                

        public Command OKCommand
        {
            get;
            private set;
        }
                
    }
}
