using System.Windows.Controls;
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
