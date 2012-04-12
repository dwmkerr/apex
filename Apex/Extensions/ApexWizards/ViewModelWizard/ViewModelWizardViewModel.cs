using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ApexWizards.ViewModelWizard
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ViewModelWizardViewModel : ViewModel
    {
        public ViewModelWizardViewModel()
        {
            OKCommand = new Command(DoOKCommand, true);
        }

        private void DoOKCommand()
        {
        }

        
        private NotifyingProperty ViewModelNameProperty =
          new NotifyingProperty("ViewModelName", typeof(string), default(string));

        public string ViewModelName
        {
            get { return (string)GetValue(ViewModelNameProperty); }
            set { SetValue(ViewModelNameProperty, value); }
        }
                
        
        private NotifyingProperty CreateExampleNotifyingPropertyProperty =
          new NotifyingProperty("CreateExampleNotifyingProperty", typeof(bool), default(bool));

        public bool CreateExampleNotifyingProperty
        {
            get { return (bool)GetValue(CreateExampleNotifyingPropertyProperty); }
            set { SetValue(CreateExampleNotifyingPropertyProperty, value); }
        }

        
        private NotifyingProperty CreateExampleObservableCollectionProperty =
          new NotifyingProperty("CreateExampleObservableCollection", typeof(bool), default(bool));

        public bool CreateExampleObservableCollection
        {
            get { return (bool)GetValue(CreateExampleObservableCollectionProperty); }
            set { SetValue(CreateExampleObservableCollectionProperty, value); }
        }

        
        private NotifyingProperty CreateExampleCommandProperty =
          new NotifyingProperty("CreateExampleCommand", typeof(bool), default(bool));

        public bool CreateExampleCommand
        {
            get { return (bool)GetValue(CreateExampleCommandProperty); }
            set { SetValue(CreateExampleCommandProperty, value); }
        }

        public Command OKCommand
        {
            get;
            private set;
        }
                
    }
}
