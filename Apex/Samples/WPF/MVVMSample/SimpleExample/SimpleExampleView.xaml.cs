using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.SimpleExample
{
    /// <summary>
    /// Interaction logic for SimpleExampleView.xaml
    /// </summary>
    public partial class SimpleExampleView : SimpleExampleViewBase
    {
        public SimpleExampleView()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Base class for the SimpleExampleView View.
    /// Until such time as XAML supports generics, we must define a base
    /// class explicitly for the view so that we can provide it in the XAML
    /// markup.
    /// </summary>
    public partial class SimpleExampleViewBase : View<SimpleExampleViewModel>
    {
    }
}
