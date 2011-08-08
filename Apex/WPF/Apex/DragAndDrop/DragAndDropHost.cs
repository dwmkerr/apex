using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Apex.Adorners;
using Apex.Consistency;

namespace Apex.DragAndDrop
{
    [TemplatePart(Name = "PART_Host", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_AdornerLayer", Type = typeof(AdornerLayer))]
    public class DragAndDropHost : ContentControl
    {
#if !SILVERLIGHT
        static DragAndDropHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragAndDropHost), new FrameworkPropertyMetadata(typeof(DragAndDropHost)));
        }
#else
        public DragAndDropHost()
        {
            this.DefaultStyleKey = typeof(DragAndDropHost);
        }
#endif
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            try
            {
                host = (Grid)GetTemplateChild("PART_Host");
                adornerLayer = (AdornerLayer)GetTemplateChild("PART_AdornerLayer");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the Drag and Drop host.");
            }
            
            host.MouseLeftButtonDown += new MouseButtonEventHandler(host_MouseDown);
            host.MouseMove += new MouseEventHandler(host_MouseMove);
            host.MouseLeftButtonUp += new MouseButtonEventHandler(host_MouseUp);
        }

        void host_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //  Perform a hist test.
            HitTest hitTest = new HitTest();
            hitTest.DoHitTest(host, e.GetPosition(host));

            //  Go through the hits, looking for a draggable object.
            foreach (var hit in hitTest.Hits)
            {
                //  Is this a draggable object?
                FrameworkElement foundDragElement, foundDragSource;
                if (hit is FrameworkElement &&
                    IsInDraggableElement((FrameworkElement)hit, out foundDragElement, out foundDragSource))
                {
                    //  We've found an object to drag - store its data.
                    dragElement = foundDragElement;
                    dragData = dragElement.DataContext;
                    dragSource = foundDragSource;
                    initialMousePosition = e.GetPosition(host);
                    initialElementOffset = e.GetPosition(dragElement);
                    break;
                }
            }
        }

        void host_MouseMove(object sender, MouseEventArgs e)
        {
            //  We only care about mouse moves if we have a drag element.
            if (dragElement == null)
                return;

            //  Update the current mouse position.
            currentMousePosition = e.GetPosition(host);

            //  We have a drag element - are we dragging?
            if (dragging == false)
            {
                //  We're not - have we moved enough to start a drag?
                //  Apex.Consistency.SystemParamters returns drag distances
                //  as SystemParameters doesn't have it in silverlight.
                if (
                    (Math.Abs(initialMousePosition.X - currentMousePosition.X) >
                Apex.Consistency.SystemParameters.MinimumHorizontalDragDistance) &&
                    (Math.Abs(initialMousePosition.Y - currentMousePosition.Y) >
                Apex.Consistency.SystemParameters.MinimumHorizontalDragDistance))
                {
                    //  We'll try starting a drag and drop.
                    DoDragAndDropStart(dragSource, dragElement, dragData);
                }
            }

            //  If we're still not dragging, we're done.
            if (dragging == false)
                return;

            //  If we have an adorner, move it.
            if (dragAdorner != null)
            {
                dragAdorner.Translation.X = currentMousePosition.X - initialElementOffset.X;
                dragAdorner.Translation.Y = currentMousePosition.Y - initialElementOffset.Y;
            }

            //  Are we over a drop target?
            FrameworkElement dropTargetOver = null;

            //  Perform a hist test.
            HitTest hitTest = new HitTest();
            hitTest.DoHitTest(host, e.GetPosition(host));

            foreach (var dt in hitTest.Hits)
            {
                FrameworkElement foundDropTarget;
                if (dt is FrameworkElement && 
                    IsInDropTarget((FrameworkElement)dt, out foundDropTarget))
                {
                    dropTargetOver = foundDropTarget;
                    break;
                }
            }

            //  If we are not over a drop target, clear the drop over.
            if (dropTargetOver == null)
            {
                dropTarget = null;
                return;
            }

            //  If we are over a drop target and it's a new one, check
            //  for continuing.
            if (dropTargetOver != dropTarget)
                DoContinueDragAndDrop(dropTargetOver);
        }

        void host_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dragging)
            {
                if (dragAdorner != null)
                    adornerLayer.RemoveAdorner(dragAdorner);
               DoDragAndDropEnd(dropTarget);
            }
        }

        private void DoDragAndDropStart(FrameworkElement dragSource, FrameworkElement dragElement,
            object dragData)
        {
            //  If we have a start handler, call it.
            DragAndDropDelegate dragAndDropStart = DragAndDropStart;
            if (dragAndDropStart != null)
            {
                DragAndDropEventArgs args = new DragAndDropEventArgs()
                {
                    DragSource = dragSource,
                    DragElement = dragElement,
                    DragData = dragData,
                    Allow = true
                };
                dragAndDropStart(this, args);
                if (args.Allow == false)
                    return;
                if (args.DragAdorner != null)
                {
                    dragAdorner = args.DragAdorner;
                    adornerLayer.AddAdorner(dragAdorner);
                }
            }

            //  Allow the drag.
            dragging = true;
        }

        private void DoContinueDragAndDrop(FrameworkElement potentialDropTarget)
        {
            //  If we have a start handler, call it.
            DragAndDropDelegate dragAndDropContinue = DragAndDropContinue;
            if (dragAndDropContinue != null)
            {
                DragAndDropEventArgs args = new DragAndDropEventArgs()
                {
                    DragSource = dragSource,
                    DragElement = dragElement,
                    DragData = dragData,
                    DropTarget = potentialDropTarget,
                    Allow = true
                };
                dragAndDropContinue(this, args);
                if (args.Allow == false)
                    return;
            }

            dropTarget = potentialDropTarget;
        }

        private void DoDragAndDropEnd(FrameworkElement dropTarget)
        {
            //  We can only do anything useful if we have a drag and drop end function.
            if (dropTarget != null)
            {
                //  Get the event handler.
                DragAndDropDelegate dragAndDropEnd = DragAndDropEnd;

                //  If we have the event handler, fire it.
                if (dragAndDropEnd != null)
                {
                    DragAndDropEventArgs args = new DragAndDropEventArgs()
                    {
                        Allow = true,
                        DragSource = dragSource,
                        DragElement = dragElement,
                        DragData = dragData,
                        DropTarget = dropTarget
                    };
                    dragAndDropEnd(this, args);
                }
            }

            //  We're done.
            dragging = false;
            dragData = null;
            dragElement = null;
            dragSource = null;
            dropTarget = null;
            dragAdorner = null;
        }

        private bool IsInDraggableElement(FrameworkElement element,
            out FrameworkElement dragElement, out FrameworkElement dragSource)
        {
            dragElement = null;
            dragSource = null;

            //  Search to see if it's a draggable element.
            FrameworkElement searchElement = element;
            do
            {
                if(DragAndDrop.GetIsDraggable(searchElement))
                {
                    dragElement = searchElement;
                    break;
                }
                searchElement = VisualTreeHelper.GetParent(searchElement) as FrameworkElement;
            } while (searchElement != null);

            //  If we didn't find a draggable element, we're done.
            if (dragElement == null)
                return false;

            //  Find the drag source that this draggable item belongs to.
            FrameworkElement findDragSource = dragElement;
            do
            {
                if (DragAndDrop.GetIsDragSource(findDragSource) == true)
                {
                    dragSource = findDragSource;
                    break;
                }
                findDragSource = VisualTreeHelper.GetParent(findDragSource) as FrameworkElement;
            } while (findDragSource != null);

            return dragSource != null;
        }
        private bool IsInDropTarget(FrameworkElement element,
            out FrameworkElement dropTarget)
        {
            dropTarget = null;

            //  Search to see if it's a draggable element.
            FrameworkElement searchElement = element;
            do
            {
                if (DragAndDrop.GetIsDropTarget(searchElement))
                {
                    dropTarget = searchElement;
                    break;
                }
                searchElement = VisualTreeHelper.GetParent(searchElement) as FrameworkElement;
            } while (searchElement != null);

            return dropTarget != null;
        }

        private Grid host;
        private AdornerLayer adornerLayer;

        private bool dragging = false;

        private FrameworkElement dragSource;
        private FrameworkElement dragElement;
        private FrameworkElement dropTarget;
        private object dragData;
        private Adorner dragAdorner;

        private Point initialMousePosition;
        private Point initialElementOffset;
        private Point currentMousePosition;

        public event DragAndDropDelegate DragAndDropStart;
        public event DragAndDropDelegate DragAndDropContinue;
        public event DragAndDropDelegate DragAndDropEnd;
    }

    public delegate void DragAndDropDelegate(object sender, DragAndDropEventArgs args);

    public class DragAndDropEventArgs : EventArgs
    {
        public bool Allow { get; set; }
        public FrameworkElement DragSource { get; set; }
        public FrameworkElement DragElement { get; set; }
        public object DragData { get; set; }
        public FrameworkElement DropTarget { get; set; }
        public Adorner DragAdorner;
    }

}
