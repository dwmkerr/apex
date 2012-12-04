using System.Windows.Controls;
using System.Windows;

namespace Apex.Controls
{
    /// <summary>
    /// Canvas that uses cartesian coordinates.
    /// </summary>
    public class CartesianCanvas : Canvas
    {
        /// <summary>
        /// Adjusts the point to cartesian coordinates.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public Point AdjustPoint(Point point)
        {
            //  Return the adjusted point.
            return new Point(point.X - origin.X, -(point.Y - origin.Y));
        }

        /// <summary>
        /// Arranges the content of a <see cref="T:System.Windows.Controls.Canvas"/> element.
        /// </summary>
        /// <param name="arrangeSize">The size that this <see cref="T:System.Windows.Controls.Canvas"/> element should use to arrange its child elements.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Size"/> that represents the arranged size of this <see cref="T:System.Windows.Controls.Canvas"/> element and its descendants.
        /// </returns>
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Point middle = new Point(arrangeSize.Width / 2, arrangeSize.Height / 2);
            origin = middle;

            foreach (UIElement element in base.InternalChildren)
            {
                if (element == null)
                {
                    continue;
                }
                double x = 0.0;
                double y = 0.0;
                double left = GetLeft(element);
                if (!double.IsNaN(left))
                {
                    x = left;
                }

                double top = GetTop(element);
                if (!double.IsNaN(top))
                {
                    y = top;
                }

                element.Arrange(new Rect(new Point(middle.X + x, middle.Y - y), element.DesiredSize));
            }
            return arrangeSize;
        }

        /// <summary>
        /// The origin.
        /// </summary>
        protected Point origin = new Point(0,0);
    }
}