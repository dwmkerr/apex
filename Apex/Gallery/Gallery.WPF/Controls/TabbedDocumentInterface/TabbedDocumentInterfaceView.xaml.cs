using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.TabbedDocumentInterface
{
    /// <summary>
    /// Interaction logic for TabbedDocumentInterfaceView.xaml
    /// </summary>
    [View(typeof(TabbedDocumentInterfaceViewModel))]
    public partial class TabbedDocumentInterfaceView : UserControl
    {
        public TabbedDocumentInterfaceView()
        {
            InitializeComponent();
        }
    }
}
