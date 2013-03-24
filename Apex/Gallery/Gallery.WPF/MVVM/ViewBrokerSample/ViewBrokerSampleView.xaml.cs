using Apex;
using Apex.MVVM;
using System.Windows.Controls;

namespace Gallery.MVVM.ViewBrokerSample
{
    /// <summary>
    /// Interaction logic for ViewBrokerSampleView.xaml
    /// </summary>
    [View(typeof(ViewBrokerSampleViewModel))]
    public partial class ViewBrokerSampleView : UserControl
    {
        public ViewBrokerSampleView()
        {
            //  Register mappings with the broker.
            ApexBroker.RegisterViewForViewModel(typeof(FolderViewModel), typeof(FolderView));
            ApexBroker.RegisterViewForViewModel(typeof(FileViewModel), typeof(FileView));

            InitializeComponent();
        }

        public ViewBrokerSampleViewModel ViewModel { get { return (ViewBrokerSampleViewModel) DataContext; } }

        private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            //  Set the selected item.
            ViewModel.SelectedItem = treeView.SelectedItem;
        }
    }
}
