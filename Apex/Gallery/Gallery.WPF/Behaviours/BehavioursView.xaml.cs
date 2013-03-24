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

namespace Gallery.Behaviours
{
    /// <summary>
    /// Interaction logic for BehavioursView.xaml
    /// </summary>
    [View(typeof(BehavioursViewModel))]
    public partial class BehavioursView : UserControl
    {
        public BehavioursView()
        {
            InitializeComponent();
        }
    }
}
