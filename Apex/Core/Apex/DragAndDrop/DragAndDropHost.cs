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
using System.Windows.Shapes;
using Apex.Adorners;
using Apex.Consistency;

namespace Apex.DragAndDrop
{
    /// <summary>
    /// The drag and drop host is a control that allows drag and drop operations
    /// to be hanlded.
    /// </summary>
    [TemplatePart(Name = "PART_Host", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_AdornerLayer", Type = typeof(AdornerLayer))]
    public class DragAndDropHost : ContentControl
    {
#if !SILVERLIGHT

        /// <summary>
        /// Initializes the <see cref="DragAndDropHost"/> class.
        /// </summary>
        static DragAndDropHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragAndDropHost), new FrameworkPropertyMetadata(typeof(DragAndDropHost)));
        }
#else
        /// <summary>
        /// Initializes the <see cref="DragAndDropHost"/> class.
        /// </summary>
        public DragAndDropHost()
        {
            this.DefaultStyleKey = typeof(DragAndDropHost);
        }
#endif
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  Get the template parts.
            try
            {
                host = (Grid)GetTemplateChild("PART_Host");
                adornerLayer = (AdornerLayer)GetTemplateChild("PART_AdornerLayer");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the Drag and Drop host.");
            }
            
            //  Register the appropriate events.
#if !SILVERLIGHT
            host.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(host_MouseDown);
#else
            host.MouseLeftButtonDown += new MouseButtonEventHandler(host_MouseDown);
#endif
            host.MouseMove += new MouseEventHandler(host_MouseMove);
            host.MouseLeftButtonUp += new MouseButtonEventHandler(host_MouseUp);
        }

        /// <summary>
        /// Handles the MouseDown event of the host control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the MouseMove event of the host control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
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
                    (Math.Abs(initialMousePosition.X - currentMousePosition.X) >=
                MinimumHorizontalDragDistance) ||
                    (Math.Abs(initialMousePosition.Y - currentMousePosition.Y) >=
                MinimumHorizontalDragDistance))
                {
                    //  We'll try starting a drag and drop.
                    DoDragAndDropStart(dragSource, dragElement, dragData);
                    if (dragging)
                        host.CaptureMouse();
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

            //  Go through each hit.
            foreach (var dt in hitTest.Hits)
            {
                //  Are we in a drop target?
                FrameworkElement foundDropTarget;
                if (dt is FrameworkElement && 
                    IsInDropTarget((FrameworkElement)dt, out foundDropTarget))
                {
                    //  We're in a drop target, store which one it is.
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

        /// <summary>
        /// Handles the MouseUp event of the host control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        void host_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //  Are we dragging?
            if (dragging)
            {
                //  Release mouse capture.
                host.ReleaseMouseCapture();

                //  If we have an adorner, remove it.
                if (dragAdorner != null)
                    adornerLayer.RemoveAdorner(dragAdorner);

                //  End drag and drop.
                DoDragAndDropEnd(dropTarget);
            }

            //  Clear all drag and drop data.
            dragData = null;
            dragSource = null;
            dragElement = null;
            dropTarget = null;
            dragAdorner = null;
        }

        /// <summary>
        /// Starts drag and drop, calling the appropriate event if it is registered.
        /// </summary>
        /// <param name="dragSource">The drag source.</param>
        /// <param name="dragElement">The drag element.</param>
        /// <param name="dragData">The drag data.</param>
        private void DoDragAndDropStart(FrameworkElement dragSource, FrameworkElement dragElement,
            object dragData)
        {
            //  If we have a start handler, call it.
            DragAndDropDelegate dragAndDropStart = DragAndDropStart;
            if (dragAndDropStart != null)
            {
                //  Create the drag args.
                DragAndDropEventArgs args = new DragAndDropEventArgs()
                {
                    DragSource = dragSource,
                    DragElement = dragElement,
                    DragData = dragData,
                    Allow = true
                };

                //  Call the event handler.
                dragAndDropStart(this, args);

                //  Has the operation been disallowed?
                if (args.Allow == false)
                {
                    //  todo extrapolate to function
                    dragging = false;
                    dragData = null;
                    dragElement = null;
                    dragSource = null;
                    dropTarget = null;
                    dragAdorner = null;
                    return;
                }

                //  Do we have an adorner?
                if (args.DragAdorner != null)
                {
                    //  Add the adorner.
                    dragAdorner = args.DragAdorner;
                    adornerLayer.AddAdorner(dragAdorner);
                }
            }

            //  Allow the drag.
            dragging = true;
        }

        /// <summary>
        /// Continues drag and drop, calling the appropriate event if it is registered.
        /// </summary>
        /// <param name="potentialDropTarget">The potential drop target.</param>
        private void DoContinueDragAndDrop(FrameworkElement potentialDropTarget)
        {
            //  If we have a start handler, call it.
            DragAndDropDelegate dragAndDropContinue = DragAndDropContinue;
            if (dragAndDropContinue != null)
            {
                //  Create the drag and drop event args.
                DragAndDropEventArgs args = new DragAndDropEventArgs()
                {
                    DragSource = dragSource,
                    DragElement = dragElement,
                    DragData = dragData,
                    DropTarget = potentialDropTarget,
                    Allow = true
                };

                //  Call the event.
                dragAndDropContinue(this, args);
                
                //  If the operation has been disallowed, return.
                if (args.Allow == false)
                    return;
            }

            //  Store the potential drop target.
            dropTarget = potentialDropTarget;
        }

        /// <summary>
        /// Ends drag and drop, calling the appropriate event if it is registered.
        /// </summary>
        /// <param name="dropTarget">The drop target.</param>
        private void DoDragAndDropEnd(FrameworkElement dropTarget)
        {
            //  Get the event handler.
            DragAndDropDelegate dragAndDropEnd = DragAndDropEnd;

            //  If we have the event handler, fire it.
            if (dragAndDropEnd != null)
            {
                //  Create the drag and drop args.
                DragAndDropEventArgs args = new DragAndDropEventArgs()
                {
                    Allow = true,
                    DragSource = dragSource,
                    DragElement = dragElement,
                    DragData = dragData,
                    DropTarget = dropTarget,
                    InitialElementOffset = initialElementOffset
                };

                //  Call the event.
                dragAndDropEnd(this, args);
            }

            //  We're done.
            dragging = false;
            dragData = null;
            dragElement = null;
            dragSource = null;
            dropTarget = null;
            dragAdorner = null;
        }

        /// <summary>
        /// Determines whether the specified element is in a draggable element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="dragElement">The drag element.</param>
        /// <param name="dragSource">The drag source.</param>
        /// <returns>
        ///   <c>true</c> if the element is in a draggable element; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Determines whether the element is in a drop target.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="dropTarget">The drop target.</param>
        /// <returns>
        ///   <c>true</c> if the element is in a drop target; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// The top level host.
        /// </summary>
        private Grid host;

        /// <summary>
        /// The adorner layer.
        /// </summary>
        private AdornerLayer adornerLayer;

        /// <summary>
        /// The dragging flag.
        /// </summary>
        private bool dragging = false;

        /// <summary>
        /// The drag source.
        /// </summary>
        private FrameworkElement dragSource;

        /// <summary>
        /// The drag element.
        /// </summary>
        private FrameworkElement dragElement;

        /// <summary>
        /// The drop target.
        /// </summary>
        private FrameworkElement dropTarget;

        /// <summary>
        /// The drag data.
        /// </summary>
        private object dragData;

        /// <summary>
        /// The drag adorner.
        /// </summary>
        private Adorner dragAdorner;

        /// <summary>
        /// The initial mouse position.
        /// </summary>
        private Point initialMousePosition;

        /// <summary>
        /// The initial element offset.
        /// </summary>
        private Point initialElementOffset;

        /// <summary>
        /// The current mouse position.
        /// </summary>
        private Point currentMousePosition;
                
        /// <summary>
        /// The MinimumHorizontalDragDistance property.
        /// </summary>
        private static readonly DependencyProperty MinimumHorizontalDragDistanceProperty =
          DependencyProperty.Register("MinimumHorizontalDragDistance", typeof(double), typeof(DragAndDropHost),
          new PropertyMetadata(Apex.Consistency.SystemParameters.MinimumHorizontalDragDistance));

        /// <summary>
        /// The MinimumVerticalDragDistance property.
        /// </summary>
        private static readonly DependencyProperty MinimumVerticalDragDistanceProperty =
          DependencyProperty.Register("MinimumVerticalDragDistance", typeof(double), typeof(DragAndDropHost),
          new PropertyMetadata(Apex.Consistency.SystemParameters.MinimumVerticalDragDistance));

        /// <summary>
        /// Gets or sets the minimum horizontal drag distance.
        /// </summary>
        /// <value>
        /// The minimum horizontal drag distance.
        /// </value>
        public double MinimumHorizontalDragDistance
        {
            get { return (double)GetValue(MinimumHorizontalDragDistanceProperty); }
            set { SetValue(MinimumHorizontalDragDistanceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum vertical drag distance.
        /// </summary>
        /// <value>
        /// The minimum vertical drag distance.
        /// </value>
        public double MinimumVerticalDragDistance
        {
            get { return (double)GetValue(MinimumVerticalDragDistanceProperty); }
            set { SetValue(MinimumVerticalDragDistanceProperty, value); }
        }

        /// <summary>
        /// Occurs when drag and drop starts.
        /// </summary>
        public event DragAndDropDelegate DragAndDropStart;

        /// <summary>
        /// Occurs when drag and drop continues.
        /// </summary>
        public event DragAndDropDelegate DragAndDropContinue;
        
        /// <summary>
        /// Occurs when drag and drop ends.
        /// </summary>
        public event DragAndDropDelegate DragAndDropEnd;
    }

    /// <summary>
    /// A Delegate for Drag and Drop events.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="Apex.DragAndDrop.DragAndDropEventArgs"/> instance containing the event data.</param>
    public delegate void DragAndDropDelegate(object sender, DragAndDropEventArgs args);
}
