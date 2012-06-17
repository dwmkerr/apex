using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Apex.MVVM;
using $safeprojectname$.ViewModels;
using Apex.Behaviours;

namespace $safeprojectname$.Views
{
    /// <summary>
    /// Interaction logic for MusicView.xaml
    /// </summary>
    [View(typeof(MusicViewModel))]
    public partial class MusicView : UserControl, IView
    {
        public MusicView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }
    }
}
