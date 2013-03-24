using System;
using System.Windows;
using System.Windows.Controls;
using Apex;
using Apex.MVVM;

namespace Gallery.Popups.SimplePopup
{
    /// <summary>
    /// Interaction logic for SimplePopupView.xaml
    /// </summary>
    [View(typeof(SimplePopupViewModel))]
    public partial class SimplePopupView : UserControl, IView
    {
        public SimplePopupView()
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
                shell.ShowPopup(new SimplePopup());
        }

        public SimplePopupViewModel ViewModel { get { return (SimplePopupViewModel)DataContext; } }
    }
}
