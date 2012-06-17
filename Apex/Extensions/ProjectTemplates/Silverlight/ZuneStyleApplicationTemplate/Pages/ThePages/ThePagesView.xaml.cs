using System.Windows.Controls;
using Apex.MVVM;
using Apex.Behaviours;

namespace $safeprojectname$.Pages.ThePages
{
    /// <summary>
    /// Interaction logic for ThePagesView.xaml
    /// </summary>
    [View(typeof(ThePagesViewModel))]
    public partial class ThePagesView : UserControl, IView
    {
        public ThePagesView()
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
