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

namespace Gallery.PathTextBox
{
    /// <summary>
    /// Interaction logic for PathTextBoxView.xaml
    /// </summary>
    [View(typeof(PathTextBoxViewModel))]
    public partial class PathTextBoxView : UserControl
    {
        public PathTextBoxView()
        {
            InitializeComponent();
        }
    }
}
