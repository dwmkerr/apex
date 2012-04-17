using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerSample
{
    /// <summary>
    /// Interaction logic for FolderView.xaml
    /// </summary>
    public partial class FolderView : FolderViewBase
    {
        public FolderView()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Base class for the FolderView View.
    /// Until such time as XAML supports generics, we must define a base
    /// class explicitly for the view so that we can provide it in the XAML
    /// markup.
    /// </summary>
    public partial class FolderViewBase : View<FolderViewModel>
    {
    }
}
