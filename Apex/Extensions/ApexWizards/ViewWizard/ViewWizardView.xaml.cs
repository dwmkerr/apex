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

namespace ApexWizards.ViewWizard
{
    /// <summary>
    /// Interaction logic for ViewWizardView.xaml
    /// </summary>
    public partial class ViewWizardView : Window
    {
        public ViewWizardView()
        {
            InitializeComponent();

            ViewModel.OKCommand.Executed += new Apex.MVVM.CommandEventHandler(OKCommand_Executed);
        }

        void OKCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            Close();
        }

        public ViewWizardViewModel ViewModel
        {
            get { return (ViewWizardViewModel)DataContext; }
        }
    }
}
