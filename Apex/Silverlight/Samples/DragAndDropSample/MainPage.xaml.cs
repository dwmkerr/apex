using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Apex.DragAndDrop;
using System.Collections.ObjectModel;
using Apex.Adorners;

namespace DragAndDropSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            dragAndDropHost.DragAndDropStart += new DragAndDropDelegate(Instance_DragAndDropStart);
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
}
