using Apex.MVVM;
using System.Windows.Controls;

namespace Gallery.MVVM.SimpleSample
{
    /// <summary>
    /// Interaction logic for SimpleExampleView.xaml
    /// </summary>
    [View(typeof(SimpleExampleViewModel))]
    public partial class SimpleExampleView : UserControl
    {
        public SimpleExampleView()
        {
            InitializeComponent();
        }
    }
}
