using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;
using Apex.DragAndDrop;
using System.Collections.ObjectModel;
using Apex.Adorners;
using System.Windows.Controls;

namespace Gallery.DragAndDrop.ItemsControlSample
{
    /// <summary>
    /// Interaction logic for ItemsControlSampleView.xaml
    /// </summary>
    [View(typeof(ItemsControlSampleViewModel))]
    public partial class ItemsControlSampleView : UserControl
    {
        public ItemsControlSampleView()
        {
            InitializeComponent(); 
            /*
            dragAndDropHost.DragAndDropStart += new DragAndDropDelegate(Instance_DragAndDropStart);
            dragAndDropHost.DragAndDropContinue += new DragAndDropDelegate(Instance_DragAndDropContinue);
            dragAndDropHost.DragAndDropEnd += new DragAndDropDelegate(Instance_DragAndDropEnd);*/
        }
        /*
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
        }*/
    }
}
