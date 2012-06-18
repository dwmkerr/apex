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

namespace WpfSelectionBug
{
    /// <summary>
    /// Interaction logic for OnionView.xaml
    /// </summary>
    [View(typeof(OnionPageViewModel))]
    public partial class OnionView : UserControl, IView
    {
        public OnionView()
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
