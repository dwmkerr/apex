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
using Apex;

namespace ZuneStyleApplication.Views
{
    /// <summary>
    /// Interaction logic for ExamplePopup.xaml
    /// </summary>
    public partial class ExamplePopup : UserControl
    {
        public ExamplePopup()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            ApexBroker.GetShell().ClosePopup(this, true);
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            ApexBroker.GetShell().ClosePopup(this, false);
        }
    }
}
