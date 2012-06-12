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
using ZuneStyleApplication.ViewModels;
using Apex;

namespace ZuneStyleApplication.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    [View(typeof(HomeViewModel))]
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApexBroker.GetShell().ShowPopup(new ExamplePopup());
        }
    }
}
