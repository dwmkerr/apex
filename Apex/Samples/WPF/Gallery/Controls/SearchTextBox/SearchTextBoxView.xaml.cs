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

namespace Gallery.SearchTextBox
{
    /// <summary>
    /// Interaction logic for SearchTextBoxView.xaml
    /// </summary>
    [View(typeof(SearchTextBoxViewModel))]
    public partial class SearchTextBoxView : UserControl
    {
        public SearchTextBoxView()
        {
            InitializeComponent();
        }
    }
}
