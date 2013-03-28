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

namespace Gallery.Controls.ImageButton
{
    /// <summary>
    /// Interaction logic for ImageButtonView.xaml
    /// </summary>
    [View(typeof(ImageButtonViewModel))]
    public partial class ImageButtonView : UserControl
    {
        public ImageButtonView()
        {
            InitializeComponent();
        }
    }
}
