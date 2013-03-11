using System.Windows.Controls;
using Apex.MVVM;
using Apex.Behaviours;

namespace Gallery.MVVM.ViewBrokerActivationSample
{
    /// <summary>
    /// Interaction logic for Page1View.xaml
    /// </summary>
    [View(typeof(Page1ViewModel))]
    public partial class Page1View : UserControl, IView
    {
        public Page1View()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Do the fade in.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }
    }
}
