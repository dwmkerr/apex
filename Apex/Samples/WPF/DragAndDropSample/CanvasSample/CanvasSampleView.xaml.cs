using System;
using System.Collections.Generic;
using System.Text;
using Apex.MVVM;
using Apex.DragAndDrop;
using System.Collections.ObjectModel;
using Apex.Adorners;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace DragAndDropSample.CanvasSample
{
    /// <summary>
    /// Interaction logic for CanvasSampleView.xaml
    /// </summary>
    public partial class CanvasSampleView : UserControl
    {
        public CanvasSampleView()
        {
            InitializeComponent(); 
            dragAndDropHost.DragAndDropStart += new DragAndDropDelegate(Instance_DragAndDropStart);
            dragAndDropHost.DragAndDropContinue += new DragAndDropDelegate(Instance_DragAndDropContinue);
            dragAndDropHost.DragAndDropEnd += new DragAndDropDelegate(Instance_DragAndDropEnd);
        }

        void Instance_DragAndDropEnd(object sender, DragAndDropEventArgs args)
        {
            Point point = Mouse.GetPosition(dragAndDropHost);
            point.Offset(-args.InitialElementOffset.X, -args.InitialElementOffset.Y);

            //  Set the position of the element.
            Canvas.SetLeft(args.DragElement, point.X);
            Canvas.SetTop(args.DragElement, point.Y);

            args.DragElement.Opacity = 1;
        }

        void Instance_DragAndDropContinue(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
        }

        void Instance_DragAndDropStart(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
            args.DragAdorner = new VisualAdorner(args.DragElement);
            args.DragElement.Opacity = 0;
        }
    }
}
