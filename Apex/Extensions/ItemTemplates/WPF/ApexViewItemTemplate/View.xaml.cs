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
    public partial class $safeitemrootname$ : UserControl, IView
    {
        public $safeitemrootname$()
        {
            InitializeComponent();
        }
    
        /// <summary>
        /// Called when the view is activated.
        /// </summary>
        public void OnActivated()
        {
        }

        /// <summary>
        /// Called when the view is deactivated.
        /// </summary>
        public void OnDeactivated()
        {
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
