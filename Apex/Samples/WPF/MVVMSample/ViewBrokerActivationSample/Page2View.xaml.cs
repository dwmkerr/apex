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

namespace MVVMSample.ViewBrokerActivationSample
{
    /// <summary>
    /// Interaction logic for Page2View.xaml
    /// </summary>
    [View(typeof(Page2ViewModel))]
    public partial class Page2View : UserControl, IView
    {
        public Page2View()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
        }

        public void OnDeactivated()
        {
        }
    }
}
