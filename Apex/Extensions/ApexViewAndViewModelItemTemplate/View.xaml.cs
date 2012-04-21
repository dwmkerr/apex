using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;

namespace $rootnamespace$
{
    /// <summary>
    /// Interaction logic for $safeitemrootname$.xaml
    /// </summary>
    public partial class $safeitemrootname$ : $safeitemrootname$Base
    {
        public $safeitemrootname$()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Base class for the $safeitemrootname$ View.
    /// Until such time as XAML supports generics, we must define a base
    /// class explicitly for the view so that we can provide it in the XAML
    /// markup.
    /// </summary>
    public partial class $safeitemrootname$Base : View<$ViewModelType$>
    {
    }
}
