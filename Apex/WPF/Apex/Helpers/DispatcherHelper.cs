using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Apex.Helpers
{
  /// <summary>
  /// Helper class for dispatcher operations.
  /// </summary>
  public static class DispatcherHelper
  {
    /// <summary>
    /// Allow the current dispatcher to do all events.
    /// </summary>
    public static void DoEvents()
    {
      DispatcherFrame frame = new DispatcherFrame();
      Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
      Dispatcher.PushFrame(frame);
    }

    /// <summary>
    /// Used internally to exit the frame.
    /// </summary>
    /// <param name="frame">The frame.</param>
    /// <returns></returns>
    private static object ExitFrame(object frame)
    {
      ((DispatcherFrame)frame).Continue = false;
      return null;
    }
  }
}
