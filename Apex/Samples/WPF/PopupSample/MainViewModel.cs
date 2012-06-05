using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace PopupSample
{
    public class MainViewModel : ViewModel  
    {
        public MainViewModel()
        {
            ShowPopupCommand = new Command(DoShowPopupCommand);
        }

        private void DoShowPopupCommand()
        {
            
        }

        public Command ShowPopupCommand { get; private set; }
    }
}
