using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerSample
{
    /// <summary>
    /// Interaction logic for FileView.xaml
    /// </summary>
    [View(typeof(FileViewModel))]
    public partial class FileView : UserControl
    {
        public FileView()
        {
            InitializeComponent();
        }
    }
}
