using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerSample
{
    /// <summary>
    /// Interaction logic for FileView.xaml
    /// </summary>
    public partial class FileView : FileViewBase
    {
        public FileView()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Base class for the FileView View.
    /// Until such time as XAML supports generics, we must define a base
    /// class explicitly for the view so that we can provide it in the XAML
    /// markup.
    /// </summary>
    public partial class FileViewBase : View<FileViewModel>
    {
    }
}
