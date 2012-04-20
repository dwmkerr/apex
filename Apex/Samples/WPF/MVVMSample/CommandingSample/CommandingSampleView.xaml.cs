using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.CommandingSample
{
    /// <summary>
    /// Interaction logic for CommandingSampleView.xaml
    /// </summary>
    public partial class CommandingSampleView : CommandingSampleViewBase
    {
        public CommandingSampleView()
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
    public partial class CommandingSampleViewBase : View<CommandingSampleViewModel>
    {
    }
}
