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
        private static bool? isDesignTime;

        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running in Blend
        /// or Visual Studio).
        /// </summary>
        public static bool IsDesignTime
        {
            get
            {
              if (!isDesignTime.HasValue)
                {
#if SILVERLIGHT
                    isDesignTime = DesignerProperties.IsInDesignTool;
#else
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    isDesignTime
                        = (bool)DependencyPropertyDescriptor
                        .FromProperty(prop, typeof(FrameworkElement))
                        .Metadata.DefaultValue;
#endif
                }

              return isDesignTime.Value;
            }
        }
    }
}
