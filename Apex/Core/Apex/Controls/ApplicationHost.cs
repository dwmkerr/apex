using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Apex.Adorners;
using Apex.DragAndDrop;
using Apex.Helpers.Popups;
using Apex.MVVM;

namespace Apex.Controls
{

    /// <summary>
    /// The application host is the main root level element of an application
    /// and provides drag and drop and popup functionality.
    /// </summary>
    [TemplatePart(Name = "PART_ApplicationHost", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_DragAndDropHost", Type = typeof(DragAndDropHost))]
    [TemplatePart(Name = "PART_PopupHost", Type = typeof(Grid))]
    public class ApplicationHost : ContentControl, IApplicationHost
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes the <see cref="ApplicationHost"/> class.
        /// </summary>
        static ApplicationHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ApplicationHost), new FrameworkPropertyMetadata(typeof(ApplicationHost)));
        }
#else
        /// <summary>
        /// Initializes the <see cref="ApplicationHost"/> class.
        /// </summary>
        public ApplicationHost()
        {
            this.DefaultStyleKey = typeof(ApplicationHost);
        }
#endif
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  Wire up the close event handler.
            PopupClosed += OnPopupClosed;

            //  Register with the broker.
            ApexBroker.RegisterApplicationHost(this);

            //  Get the template parts.
            try
            {
                applicationHost = (Grid)GetTemplateChild("PART_ApplicationHost");
                dragAndDropHost = (DragAndDropHost)GetTemplateChild("PART_DragAndDropHost");
                popupHost = (Grid)GetTemplateChild("PART_PopupHost");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the Application host.");
            }
        }
        
        void OnPopupClosed(object sender, RoutedEventArgs e)
        {
            //  Get the top popup.
            var topPopup = popupStack.Peek();

            //  Pop the top popup.
            popupStack.Pop();

            //  Cancel the dispatcher frame.
            topPopup.Item2.Continue = false;

            //  Store the popup result.
            lastPopupResult = topPopup.Item1.GetPopupResult();
        }

        /// <summary>
        /// Pushes a popup onto the popup stack.
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <returns>
        /// The popup result.
        /// </returns>
        public object ShowPopup(IPopup popup)
        {
            //  Raise the popup opened event.
            var args = new RoutedEventArgs(PopupOpenedEvent);
            RaiseEvent(args);

            //  Create a new dispatcher frame.
            var dispatcherFrame = new DispatcherFrame();
      
            //  Push our popup onto the popup stack.
            popupStack.Push(Tuple.Create(popup, dispatcherFrame));

            //  Transition the popup.
            popupAnimationHelper.ShowPopup(popupHost, popup);
            
            //  Push the dispatcher frame - this will now block until we close the popup.
            System.Windows.Threading.Dispatcher.PushFrame(dispatcherFrame); 

            //  Return the last popup result.
            return lastPopupResult;
        }

        /// <summary>
        /// Closes the popup.
        /// </summary>
        /// <param name="popup">The popup.</param>
        public void ClosePopup(IPopup popup)
        {
            //  Make sure we're the top of the stack.
            if(popupStack.Peek().Item1 != popup)
                throw new InvalidOperationException("Cannot close the specified popup - it is not the top of the popup stack.");

            //  Transition the popup.
            popupAnimationHelper.ClosePopup(popupHost, popup);

            //  Raise the close event.
            var eventArgs = new RoutedEventArgs(PopupClosedEvent);
            RaiseEvent(eventArgs);
        }

       
        /// <summary>
        /// The top level application host.
        /// </summary>
        private Grid applicationHost;

        /// <summary>
        /// The drag and drop host.
        /// </summary>
        private DragAndDropHost dragAndDropHost;
        
        /// <summary>
        /// The popup host.
        /// </summary>
        private Grid popupHost;

        /// <summary>
        /// The current stack of popups.
        /// </summary>
        private Stack<Tuple<IPopup, DispatcherFrame>> popupStack = new Stack<Tuple<IPopup, DispatcherFrame>>();

        /// <summary>
        /// The last popup result.
        /// </summary>
        private object lastPopupResult;

        /// <summary>
        /// The popup animation helper, fade in by default.
        /// </summary>
        private PopupAnimationHelper popupAnimationHelper = new BounceInOutPopupAnimationHelper() { BounceInDirection = 180, BounceOutDirection = 180 };

        /// <summary>
        /// Occurs when a popup is opened.
        /// </summary>
        public static readonly RoutedEvent PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ApplicationHost));

        /// <summary>
        /// Occurs when a popup is closed.
        /// </summary>
        public static readonly RoutedEvent PopupClosedEvent = EventManager.RegisterRoutedEvent("PopupClosed",
            RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(ApplicationHost));

        /// <summary>
        /// Occurs when a popup is opened.
        /// </summary>
        public event RoutedEventHandler PopupOpened
        {
            add { AddHandler(PopupOpenedEvent, value); }
            remove { RemoveHandler(PopupOpenedEvent, value); }
        }

        /// <summary>
        /// Occurs when a popup is closed.
        /// </summary>
        public event RoutedEventHandler PopupClosed
        {
            add { AddHandler(PopupClosedEvent, value); }
            remove { RemoveHandler(PopupClosedEvent, value); }
        }

        /// <summary>
        /// Gets or sets the popup animation helper.
        /// </summary>
        /// <value>
        /// The popup animation helper.
        /// </value>
        public PopupAnimationHelper PopupAnimationHelper
        {
            get { return popupAnimationHelper; }
            set 
            {
                if(value == null) 
                    throw new ArgumentException("Popup animation helper cannot be null.");
                if(popupAnimationHelper.OpenPopupsCount > 0)
                    throw new InvalidOperationException("Cannot change the popup animation helper - there are popups open.");
                popupAnimationHelper = value;
            }
        }
    }
}
