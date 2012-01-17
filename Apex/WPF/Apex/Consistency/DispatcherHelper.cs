
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Windows.Threading;

namespace Apex.Consistency
{

  /// <summary>
  /// Helper to make Dispatcher functions consistent in WPF/SL/WP7.
  /// </summary>
  public static class DispatcherHelper
  {
    public static Dispatcher CurrentDispatcher
    {
      get
      {
        //  Return the dispatcher.
#if !SILVERLIGHT
        return Dispatcher.CurrentDispatcher;
#else
       return System.Windows.Application.Current.RootVisual.Dispatcher;
#endif
      }
    }
  }
}
