using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerSample
{
    /// <summary>
    /// Interaction logic for FolderView.xaml
    /// </summary>
    [View(typeof(FolderViewModel))]
    public partial class FolderView : UserControl
    {
        public FolderView()
        {
            InitializeComponent();
        }
    }
}
