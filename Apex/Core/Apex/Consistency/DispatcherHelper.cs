
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Windows;
  using System.Windows.Threading;
  using Apex.MVVM;

namespace Apex.Consistency
{

    /// <summary>
    /// Helper to make Dispatcher functions consistent in WPF/SL/WP7.
    /// </summary>
    public static class DispatcherHelper
    {
        /// <summary>
        /// Gets the current dispatcher.
        /// </summary>
        public static Dispatcher CurrentDispatcher
        {
            get
            {
                //  Return the dispatcher.
#if !SILVERLIGHT
                return Dispatcher.CurrentDispatcher;
#else
          if (Application.Current.RootVisual != null)
              return Application.Current.RootVisual.Dispatcher;
          else if (ApexBroker.GetShell() != null && ApexBroker.GetShell() is UIElement)
              return ((UIElement) ApexBroker.GetShell()).Dispatcher;
          else
          {
              throw new InvalidOperationException("Cannot find a root element to get a dispatcher. Try including a Shell as a top level element.");
          }
#endif
            }
        }
    }
}
