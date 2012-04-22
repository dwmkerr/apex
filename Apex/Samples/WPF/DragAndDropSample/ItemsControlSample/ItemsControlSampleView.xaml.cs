using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;
using Apex.DragAndDrop;
using System.Collections.ObjectModel;
using Apex.Adorners;
using System.Windows.Controls;

namespace DragAndDropSample.ItemsControlSample
{
    /// <summary>
    /// Interaction logic for ItemsControlSampleView.xaml
    /// </summary>
    public partial class ItemsControlSampleView : ItemsControlSampleViewBase
    {
        public ItemsControlSampleView()
        {
            InitializeComponent(); dragAndDropHost.DragAndDropStart += new DragAndDropDelegate(Instance_DragAndDropStart);
            dragAndDropHost.DragAndDropContinue += new DragAndDropDelegate(Instance_DragAndDropContinue);
            dragAndDropHost.DragAndDropEnd += new DragAndDropDelegate(Instance_DragAndDropEnd);
        }

        void Instance_DragAndDropEnd(object sender, DragAndDropEventArgs args)
        {
            ObservableCollection<string> from =
                ((ItemsControl)args.DragSource).ItemsSource as ObservableCollection<string>;
            ObservableCollection<string> to =
                ((ItemsControl)args.DropTarget).ItemsSource as ObservableCollection<string>;
            from.Remove((string)args.DragData);
            to.Add((string)args.DragData);
        }

        void Instance_DragAndDropContinue(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
        }

        void Instance_DragAndDropStart(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
            args.DragAdorner = new VisualAdorner(args.DragElement);
        }
    }

    /// <summary>
    /// Base class for the ItemsControlSampleView View.
    /// Until such time as XAML supports generics, we must define a base
    /// class explicitly for the view so that we can provide it in the XAML
    /// markup.
    /// </summary>
    public partial class ItemsControlSampleViewBase : View<ItemsControlSampleViewModel>
    {
    }
}
