using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.PivotControl
{
    /// <summary>
    /// Interaction logic for PivotControlView.xaml
    /// </summary>
    [View(typeof(PivotControlViewModel))]
    public partial class PivotControlView : UserControl
    {
        public PivotControlView()
        {
            InitializeComponent();
        }
    }
}
