using System.Windows;
using System.Windows.Controls;
using Apex;
using Apex.MVVM;

namespace Gallery.Popups.CustomisedPopup
{
    /// <summary>
    /// Interaction logic for SimplePopupView.xaml
    /// </summary>
    [View(typeof(CustomisedPopupViewModel))]
    public partial class CustomisedPopupView : UserControl, IView
    {
        public CustomisedPopupView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            ViewModel.ShowPopupCommand.Executing += ShowPopupCommandOnExecuting;
        }

        public void OnDeactivated()
        {
            ViewModel.ShowPopupCommand.Executing -= ShowPopupCommandOnExecuting;
        }

        private void ShowPopupCommandOnExecuting(object sender, CancelCommandEventArgs args)
        {
            var shell = ApexBroker.GetShell();
            ViewModel.PopupResult =
                shell.ShowPopup(new CustomisedPopup());
        }

        public CustomisedPopupViewModel ViewModel { get { return (CustomisedPopupViewModel)DataContext; } }
    }
}
