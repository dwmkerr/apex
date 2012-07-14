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
using Gallery.Controls.CrossButton;

namespace ControlsSample.Samples
{
    /// <summary>
    /// Interaction logic for CrossButton.xaml
    /// </summary>
    [View(typeof(CrossButtonViewModel))]
    public partial class CrossButton : UserControl
    {
        public CrossButton()
        {
            InitializeComponent();
        }
    }
}
