using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Apex.Controls;
using Apex.DragAndDrop;
using Apex.Helpers.Popups;
using Apex.Extensions;

namespace Apex.Shells
{
    /// <summary>
    /// The shell is a control used internally to provide the bulk of shell operations valid 
    /// across all platforms - popups, drag and drop etc.
    /// </summary>
    [TemplatePart(Name = "PART_ApplicationHost", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_DragAndDropHost", Type = typeof(DragAndDropHost))]
    [TemplatePart(Name = "PART_PopupHost", Type = typeof(Grid))]
    public class Shell : ContentControl, IShell
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes the <see cref="Shell"/> class.
        /// </summary>
        static Shell()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Shell), new FrameworkPropertyMetadata(typeof(Shell)));
        }
#else
        /// <summary>
        /// Initializes the <see cref="Shell"/> class.
        /// </summary>
        public Shell()
        {
            this.DefaultStyleKey = typeof(Shell);
        }
#endif
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  Register the shell.
            ApexBroker.RegisterShell(this);

            //  Wire up the close event handler.
            PopupClosed += OnPopupClosed;
            
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


#if !SILVERLIGHT

        /// <summary>
        /// Minimizes the shell, if supported.
        /// </summary>
        public void DoMinimize()
        {
            //  Get the parent window.
            var parentWindow = this.GetParentWindow();
            if (parentWindow == null)
                throw new InvalidOperationException("Cannot minimize shell - parent window cannot be found.");
            parentWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Maximizes the shell, if supported.
        /// </summary>
        public void DoMaximize()
        {
            //  Get the parent window.
            var parentWindow = this.GetParentWindow();
            if (parentWindow == null)
                throw new InvalidOperationException("Cannot maximize shell - parent window cannot be found.");
            parentWindow.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Restores the shell, if supported.
        /// </summary>
        public void DoRestore()
        {
            //  Get the parent window.
            var parentWindow = this.GetParentWindow();
            if (parentWindow == null)
                throw new InvalidOperationException("Cannot restore shell - parent window cannot be found.");
            parentWindow.WindowState = WindowState.Normal;
        }

        /// <summary>
        /// Closes the shell, if supported.
        /// </summary>
        public void DoClose()
        {
            //  Get the parent window.
            var parentWindow = this.GetParentWindow();
            if (parentWindow == null)
                throw new InvalidOperationException("Cannot close shell - parent window cannot be found.");
            parentWindow.Close();
        }

#endif

        /// <summary>
        /// Fullscreens the shell, if supported.
        /// </summary>
        public void DoFullscreen()
        {
            throw new NotImplementedException();
        }

#if !SILVERLIGHT

        /// <summary>
        /// Pushes a popup onto the popup stack.
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <returns>
        /// The popup result.
        /// </returns>
        public object ShowPopup(UIElement popup)
        {
            //  Raise the popup opened event.
            var args = new RoutedEventArgs(PopupOpenedEvent);
            RaiseEvent(args);

            //  Create a new popup state with a new dispatcher frame.
            var popupState = new PopupState()
            {
                PopupElement = popup,
                DispatcherFrame = new DispatcherFrame()
            };
            
            //  Push our popup state onto the popup stack.
            popupStack.Push(popupState);

            //  Transition the popup.
            popupAnimationHelper.ShowPopup(popupHost, popup);
            
            //  Push the dispatcher frame - this will now block until we close the popup.
            Dispatcher.PushFrame(popupState.DispatcherFrame); 

            //  Return the popup result (which by now will be stored in its state).
            return popupState.PopupResult;
        }
        
        /// <summary>
        /// Called when a popup is closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void OnPopupClosed(object sender, RoutedEventArgs e)
        {
            //  Get the top popup.
            var topPopup = popupStack.Peek();

            //  Pop the top popup.
            popupStack.Pop();

            //  Cancel the dispatcher frame.
            topPopup.DispatcherFrame.Continue = false;
        }
#else
        
        /// <summary>
        /// Pushes a popup onto the popup stack.
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <param name="onPopopClosed">The action to invoke when the popop is closed.</param>
        public void ShowPopup(UIElement popup, Action<object> onPopopClosed)
        {
            //  Fire the popup opened event.
            FirePopupOpened();

            //  Create the popup state.
            var popupState = new PopupState()
            {
                PopupElement = popup,
                ClosedAction = onPopopClosed
            };
            
            //  Push our popup onto the popup stack.
            popupStack.Push(popupState);

            //  Transition the popup.
            popupAnimationHelper.ShowPopup(popupHost, popup);
        }
        
        /// <summary>
        /// Called when a popup is closed.
        /// </summary>
        void OnPopupClosed()
        {
            //  Get the top popup.
            var topPopup = popupStack.Peek();

            //  Pop the top popup.
            popupStack.Pop();
        
            //  Fire the action.
            var theAction = topPopup.ClosedAction;
            if(theAction != null)
                theAction(topPopup.PopupResult);
        }

#endif

        /// <summary>
        /// Closes the popup.
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <param name="result">The popup result, which will be provided to the caller of ShowPopup.</param>
        public void ClosePopup(UIElement popup, object result)
        {
            //  Make sure we're the top of the stack.
            if(popupStack.Peek().PopupElement != popup)
                throw new InvalidOperationException("Cannot close the specified popup - it is not the top of the popup stack.");

            //  Store the popup result.
            popupStack.Peek().PopupResult = result;

            //  Transition the popup.
            popupAnimationHelper.ClosePopup(popupHost, popup);

            //  Raise the close event.
            FirePopupClosed();
        }

        /// <summary>
        /// Fires the popup opened event.
        /// </summary>
        protected virtual void FirePopupOpened()
        {
#if !SILVERLIGHT
            //  Raise the popup opened event.
            var args = new RoutedEventArgs(PopupOpenedEvent);
            RaiseEvent(args);
#else
            //  Raise the popup opened event.
            var theEvent = PopupOpened;
            if(theEvent != null)
                theEvent();
#endif
        }

        /// <summary>
        /// Fires the popup closed event.
        /// </summary>
        protected virtual void FirePopupClosed()
        {
#if !SILVERLIGHT
            //  Raise the popup closed event.
            var args = new RoutedEventArgs(PopupClosedEvent);
            RaiseEvent(args);
#else
            //  Raise the popup closed event.
            var theEvent = PopupClosed;
            if(theEvent != null)
                theEvent();
#endif
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
        private readonly Stack<PopupState> popupStack =
            new Stack<PopupState>();

        /// <summary>
        /// The popup animation helper, fade in by default.
        /// </summary>
        private PopupAnimationHelper popupAnimationHelper = new BounceInOutPopupAnimationHelper() { BounceInDirection = 180, BounceOutDirection = 180 };

#if !SILVERLIGHT

        /// <summary>
        /// Occurs when a popup is opened.
        /// </summary>
        public static readonly RoutedEvent PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Shell));

        /// <summary>
        /// Occurs when a popup is closed.
        /// </summary>
        public static readonly RoutedEvent PopupClosedEvent = EventManager.RegisterRoutedEvent("PopupClosed",
            RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(Shell));

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

#else

        /// <summary>
        /// Occurs when a popup is opened.
        /// </summary>
        public event Action PopupOpened;

        /// <summary>
        /// Occurs when a popup is closed.
        /// </summary>
        public event Action PopupClosed;

#endif

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

        internal class PopupState
        {
            public UIElement PopupElement { get; set; }
#if !SILVERLIGHT
            public DispatcherFrame DispatcherFrame { get; set; }
#else
            public Action<object> ClosedAction { get; set; }
#endif
            public object PopupResult { get; set; }
        }
    }
}
