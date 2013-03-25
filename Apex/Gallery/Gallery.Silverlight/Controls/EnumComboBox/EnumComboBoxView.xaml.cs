using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.EnumComboBox
{
    /// <summary>
  /// Interaction logic for EnumComboBox.xaml
    /// </summary>
    [View(typeof(EnumComboBoxViewModel))]
    public partial class EnumComboBoxView : UserControl
    {
        public EnumComboBoxView()
        {
            InitializeComponent();
        }
    }
}
