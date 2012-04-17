using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerSample
{
    /// <summary>
    /// Interaction logic for ViewBrokerSampleView.xaml
    /// </summary>
    public partial class ViewBrokerSampleView : ViewBrokerSampleViewBase
    {
        public ViewBrokerSampleView()
        {
            //  Register mappings with the broker.
            var globalBroker = Apex.MVVM.ApexBroker.GlobalBroker;
            globalBroker.RegisterViewForViewModel(typeof(FolderViewModel), typeof(FolderView));
            globalBroker.RegisterViewForViewModel(typeof(FileViewModel), typeof(FileView));

            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            //  Set the selected item.
            viewModel.SelectedItem = treeView.SelectedItem;
        }
    }

    /// <summary>
    /// Base class for the ViewBrokerSampleView View.
    /// Until such time as XAML supports generics, we must define a base
    /// class explicitly for the view so that we can provide it in the XAML
    /// markup.
    /// </summary>
    public partial class ViewBrokerSampleViewBase : View<ViewBrokerSampleViewModel>
    {
    }
}
