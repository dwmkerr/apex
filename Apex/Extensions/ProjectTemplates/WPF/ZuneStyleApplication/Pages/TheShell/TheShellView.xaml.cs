using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Apex;
using Apex.MVVM;
using ZuneStyleApplication.ViewModels;
using Apex.Behaviours;
using ZuneStyleApplication.Views;

namespace ZuneStyleApplication.Pages.TheShell
{
    /// <summary>
    /// Interaction logic for TheShellView.xaml
    /// </summary>
    [View(typeof(TheShellViewModel))]
    public partial class TheShellView : UserControl, IView
    {
        public TheShellView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);

            //  Handle the 'show popup' executed event.
            viewModel.ShowPopupCommand.Executed += ShowPopupCommand_Executed;
        }

        /// <summary>
        /// Handles the Executed event of the ShowPopupCommand.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Apex.MVVM.CommandEventArgs"/> instance containing the event data.</param>
        void ShowPopupCommand_Executed(object sender, CommandEventArgs args)
        {
            //  Get the shell and show the example popup.
            ApexBroker.GetShell().ShowPopup(new ExamplePopup());
        }

        public void OnDeactivated()
        {
        }
    }
}
