using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.CommandingSample
{
    /// <summary>
    /// Interaction logic for CommandingSampleView.xaml
    /// </summary>
    [View(typeof(CommandingSampleViewModel))]
    public partial class CommandingSampleView : UserControl
    {
        public CommandingSampleView()
        {
            InitializeComponent();
        }
    }
}
