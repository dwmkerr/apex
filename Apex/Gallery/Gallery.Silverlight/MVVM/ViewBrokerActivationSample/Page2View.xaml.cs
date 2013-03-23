using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerActivationSample
{
    /// <summary>
    /// Interaction logic for Page2View.xaml
    /// </summary>
    [View(typeof(Page2ViewModel))]
    public partial class Page2View : UserControl, IView
    {
        public Page2View()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
        }

        public void OnDeactivated()
        {
        }
    }
}
