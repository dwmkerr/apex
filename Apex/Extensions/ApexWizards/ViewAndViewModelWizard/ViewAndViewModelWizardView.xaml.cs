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
using System.Windows.Shapes;

namespace ApexWizards.ViewAndViewModelWizard
{
    /// <summary>
    /// Interaction logic for ViewAndViewModelWizardView.xaml
    /// </summary>
    public partial class ViewAndViewModelWizardView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAndViewModelWizardView"/> class.
        /// </summary>
        public ViewAndViewModelWizardView()
        {
            InitializeComponent();

            ViewModel.OKCommand.Executed += new Apex.MVVM.CommandEventHandler(OKCommand_Executed);
        }

        /// <summary>
        /// Handles the Executed event of the OKCommand control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Apex.MVVM.CommandEventArgs"/> instance containing the event data.</param>
        void OKCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            Close();
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        public ViewAndViewModelWizardViewModel ViewModel
        {
            get { return (ViewAndViewModelWizardViewModel)DataContext; }
        }
    }
}
