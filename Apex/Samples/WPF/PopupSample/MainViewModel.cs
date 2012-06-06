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
            UseDiagonalSlideInOuAnimationHelperCommand = new Command(DoUseDiagonalSlideInOutAnimationHelperCommand);
        }

        private void DoShowPopupCommand()
        {
            
        }

        private void DoUseFadeInOutAnimationHelperCommand()
        {
            ApexBroker.GlobalBroker.GetApplicationHost().PopupAnimationHelper = new FadeInOutPopupAnimationHelper();
        }

        private void DoUseBounceUpDownOutAnimationHelperCommand()
        {
            ApexBroker.GlobalBroker.GetApplicationHost().PopupAnimationHelper = new BounceUpDownPopupAnimationHelper();
        }

        private void DoUseDiagonalSlideInOutAnimationHelperCommand()
        {
            ApexBroker.GlobalBroker.GetApplicationHost().PopupAnimationHelper = new DiagnonalSlideInOutPopupAnimationHelper();
        }

        public Command ShowPopupCommand { get; private set; }

        public Command UseFadeInOutAnimationHelperCommand { get; private set; }

        public Command UseBounceUpDownAnimationHelperCommand { get; private set; }

        public Command UseDiagonalSlideInOuAnimationHelperCommand { get; private set; }
    }
}
