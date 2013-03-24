using System.Windows;
using System.Windows.Controls;
using Apex;

namespace Gallery.Popups.CustomisedPopup
{
    /// <summary>
    /// Interaction logic for SimplePopup.xaml
    /// </summary>
    public partial class CustomisedPopup : UserControl
    {
        public CustomisedPopup()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ApexBroker.GetShell().ClosePopup(this, null);
        }
    }
}
