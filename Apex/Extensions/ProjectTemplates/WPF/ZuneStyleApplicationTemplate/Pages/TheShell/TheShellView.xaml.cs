using System.Windows.Controls;
using Apex;
using Apex.MVVM;
using Apex.Behaviours;
using $safeprojectname$.Views;

namespace $safeprojectname$.Pages.TheShell
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
            ((TheShellViewModel)DataContext).ShowPopupCommand.Executed += ShowPopupCommand_Executed;
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
            //  Remove the handler for the 'show popup' executed event.
            ((TheShellViewModel)DataContext).ShowPopupCommand.Executed -= ShowPopupCommand_Executed;
        }
    }
}
