using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Apex.Consistency
{
  /// <summary>
  /// Provides a Silverlight/WPF indenpendent way to hit-test a point on the screen.
  /// </summary>
    public class HitTest
    {
      /// <summary>
      /// The set of hit test results.
      /// </summary>
        private List<UIElement> results = new List<UIElement>();

        /// <summary>
        /// Performs the hit test.
        /// </summary>
        /// <param name="rootElement">The root element.</param>
        /// <param name="point">The point, relative to the root element.</param>
        public void DoHitTest(UIElement rootElement, Point point)
        {
#if SILVERLIGHT
            results = VisualTreeHelper.FindElementsInHostCoordinates(point, rootElement).ToList();
#else
            results.Clear();
            VisualTreeHelper.HitTest(rootElement, null, 
                new HitTestResultCallback(HitTestCallback), new PointHitTestParameters(point));
#endif
        }

#if !SILVERLIGHT

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            if (result.VisualHit is UIElement)
                results.Add(result.VisualHit as UIElement);
            return HitTestResultBehavior.Continue;
        }

#endif
        /// <summary>
        /// Gets the hit-test hits.
        /// </summary>
        public List<UIElement> Hits
        {
            get { return results; }
        }
    }
}
