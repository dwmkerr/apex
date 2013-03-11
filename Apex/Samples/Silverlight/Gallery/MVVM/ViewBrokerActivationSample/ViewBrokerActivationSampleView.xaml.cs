using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerActivationSample
{
    /// <summary>
    /// Interaction logic for ViewBrokerActivationSampleView.xaml
    /// </summary>
    [View(typeof(ViewBrokerActivationSampleViewModel))]
    public partial class ViewBrokerActivationSampleView : UserControl
    {
        public ViewBrokerActivationSampleView()
        {
            InitializeComponent();
        }
    }
}
