using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.Helpers.Popups;
using Apex.MVVM;

namespace PopupSample
{
    public class MainViewModel : ViewModel  
    {
        public MainViewModel()
        {
            ShowPopupCommand = new Command(DoShowPopupCommand);
            UseFadeInOutAnimationHelperCommand = new Command(DoUseFadeInOutAnimationHelperCommand);
            UseBounceUpDownAnimationHelperCommand = new Command(DoUseBounceUpDownOutAnimationHelperCommand);
        }

        private void DoShowPopupCommand()
        {
            
        }

        private void DoUseFadeInOutAnimationHelperCommand()
        {
            ApexBroker.GetApplicationHost().PopupAnimationHelper = new FadeInOutPopupAnimationHelper();
        }

        private void DoUseBounceUpDownOutAnimationHelperCommand()
        {
            ApexBroker.GetApplicationHost().PopupAnimationHelper = new BounceInOutPopupAnimationHelper();
        }

        public Command ShowPopupCommand { get; private set; }

        public Command UseFadeInOutAnimationHelperCommand { get; private set; }

        public Command UseBounceUpDownAnimationHelperCommand { get; private set; }
    }
}
