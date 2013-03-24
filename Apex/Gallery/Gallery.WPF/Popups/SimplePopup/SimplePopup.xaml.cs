using System.Windows;
using System.Windows.Controls;
using Apex;

namespace Gallery.Popups.SimplePopup
{
    /// <summary>
    /// Interaction logic for SimplePopup.xaml
    /// </summary>
    public partial class SimplePopup : UserControl
    {
        public SimplePopup()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ApexBroker.GetShell().ClosePopup(this, "The Popup Result");
        }
    }
}
