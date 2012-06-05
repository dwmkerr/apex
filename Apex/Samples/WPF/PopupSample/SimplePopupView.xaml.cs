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
    /// Interaction logic for SimplePopupView.xaml
    /// </summary>
    public partial class SimplePopupView : UserControl, IPopup
    {
        public SimplePopupView()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ApexBroker.GlobalBroker.GetApplicationHost().ClosePopup(this);
        }

        public object GetPopupResult()
        {
            return null;
        }
    }
}
