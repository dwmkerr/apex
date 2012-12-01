using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Apex.MVVM;

namespace $rootnamespace$
{
    /// <summary>
    /// Interaction logic for $safeitemrootname$.xaml
    /// </summary>
    [View(typeof($ViewModelType$))]
    public partial class $safeitemrootname$ : UserControl
    {
        public $safeitemrootname$()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the ViewModel.
        /// </summary>
        public $ViewModelType$ ViewModel
        {
            get { return ($ViewModelType$) DataContext; }
        }
    }
}
