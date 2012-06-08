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

namespace ApexWizards.ViewModelWizard
{
    /// <summary>
    /// Interaction logic for ViewModelWizardView.xaml
    /// </summary>
    public partial class ViewModelWizardView : Window
    {
        public ViewModelWizardView()
        {
            InitializeComponent();

            ViewModel.OKCommand.Executed += new Apex.MVVM.CommandEventHandler(OKCommand_Executed);
            ViewModel.CancelCommand.Executed += new Apex.MVVM.CommandEventHandler(CancelCommand_Executed);
        }

        /// <summary>
        /// Handles the Executed event of the CancelCommand control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Apex.MVVM.CommandEventArgs"/> instance containing the event data.</param>
        void CancelCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            DialogResult = false;
            Close();
        }

        void OKCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            DialogResult = true;
            Close();
        }

        public ViewModelWizardViewModel ViewModel
        {
            get { return (ViewModelWizardViewModel)DataContext; }
        }
    }
}
