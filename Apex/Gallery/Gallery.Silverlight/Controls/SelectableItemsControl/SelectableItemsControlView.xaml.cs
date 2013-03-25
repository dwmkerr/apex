using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.SelectableItemsControl
{
    /// <summary>
    /// Interaction logic for SelectableItemsControlView.xaml
    /// </summary>
    [View(typeof(SelectableItemsControlViewModel))]
    public partial class SelectableItemsControlView : UserControl
    {
        public SelectableItemsControlView()
        {
            InitializeComponent();
        }
    }
}
