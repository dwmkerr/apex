using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Consistency
{
  /// <summary>
  /// Provides a Silverlight/WPF independent way to get system parameters
  /// not in both platforms.
  /// </summary>
    public static class SystemParameters
    {
        public static double MinimumHorizontalDragDistance
        {
            get 
            {
#if SILVERLIGHT
                return 4.0;
#else
                return System.Windows.SystemParameters.MinimumHorizontalDragDistance;
#endif
            }
        }
        
        public static double MinimumVerticalDragDistance
        {
            get 
            {
#if SILVERLIGHT
                return 4.0;
#else
                return System.Windows.SystemParameters.MinimumVerticalDragDistance;
#endif
            }
        }
    }
}
