using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Apex.Consistency
{
    public class HitTest
    {
        private List<UIElement> results = new List<UIElement>();
        public void DoHitTest(UIElement rootElement, Point point)
        {
#if SILVERLIGHT
            results = VisualTreeHelper.FindElementsInHostCoordinates(point, rootElement).ToList();
#else
            results.Clear();
            VisualTreeHelper.HitTest(rootElement, null, 
                new HitTestResultCallback(myCallback), new PointHitTestParameters(point));
#endif
        }

#if !SILVERLIGHT
        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        private HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit is UIElement)
                results.Add(result.VisualHit as UIElement);
            return HitTestResultBehavior.Continue;
        }

#endif
        public List<UIElement> Hits
        {
            get { return results; }
        }
    }
}
