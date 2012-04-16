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
            InitializeComponent();
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
