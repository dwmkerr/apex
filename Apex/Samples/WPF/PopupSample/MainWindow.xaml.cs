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
using Apex.MVVM;

namespace PopupSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            viewModel.ShowPopupCommand.Executed += new Apex.MVVM.CommandEventHandler(ShowPopupCommand_Executed);
        }

        void ShowPopupCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            var appHost = ApexBroker.GetApplicationHost();
            appHost.ShowPopup(new SimplePopupView());
        }
    }
}
