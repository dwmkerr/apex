using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace Apex.Design
{
  /// <summary>
  /// Class for design time functionality.
  /// </summary>
    public static class DesignTime
    {
        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running in Blend
        /// or Visual Studio).
        /// </summary>
        public static bool IsDesignTime
        {
            get
            {
              
#if SILVERLIGHT
                    return DesignerProperties.IsInDesignTool;
#else
                    return DesignerProperties.GetIsInDesignMode(new DependencyObject());
#endif
                
            }
        }
    }
}
