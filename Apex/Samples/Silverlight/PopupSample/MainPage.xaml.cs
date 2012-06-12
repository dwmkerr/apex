using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Apex;
using Apex.MVVM;

namespace PopupSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            viewModel = DataContext as MainViewModel;
            viewModel.ShowPopupCommand.Executed += new Apex.MVVM.CommandEventHandler(ShowPopupCommand_Executed);
        }

        void ShowPopupCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            var appHost = ApexBroker.GetShell();
            appHost.ShowPopup(new SimplePopupView(), (result) => {});
        }
    }
}
