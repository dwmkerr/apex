using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Apex.Extensions;

namespace Apex.Consistency
{
    /// <summary>
    /// Helper class for the logical tree.
    /// </summary>
    public static class LogicalTreeHelper
    {
        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <returns></returns>
        public static IEnumerable GetChildren(DependencyObject current)
        {
            var children = new List<DependencyObject>();
            var content = TryGetContent(current);
            var kids = TryGetChildren(current);

            if (content != null && content is DependencyObject)
                children.Add((DependencyObject)content);
            if (kids != null)
                foreach (var child in kids)
                    if (child is DependencyObject)
                        children.Add((DependencyObject) child);
            return children;
        }

        /// <summary>
        /// Tries to get the content.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static object TryGetContent(DependencyObject dependencyObject)
        {
            var prop = dependencyObject.GetType().GetProperty("Content");
            if (prop != null)
                return prop.GetValue(dependencyObject, null);
            return null;
        }


        /// <summary>
        /// Tries to get the children.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static IEnumerable TryGetChildren(DependencyObject dependencyObject)
        {
            var prop = dependencyObject.GetType().GetProperty("Children");
            if (prop != null)
                return prop.GetValue(dependencyObject, null) as IEnumerable;
            return null;
        }
    }
}
