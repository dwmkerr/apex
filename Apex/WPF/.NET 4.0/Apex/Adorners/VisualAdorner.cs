using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Apex.Extensions;

namespace Apex.Adorners 
{
    public class VisualAdorner : Adorner
    {
        public VisualAdorner(FrameworkElement visual)
        {
            //  Create a brush that draws the visual.
#if !SILVERLIGHT
            //VisualBrush _brush = new VisualBrush(visual);

            ImageBrush _brush = new ImageBrush(visual.RenderBitmap());
#else
            SolidColorBrush _brush = new SolidColorBrush(Colors.Red);
#endif

            

            //  Create a rectangle that will be painted with the visual.
            Rectangle r = new Rectangle();

            //  Set the rectangle dimensions to the be the same as the visual.
            r.Width = visual.ActualWidth;
            r.Height = visual.ActualHeight;
            r.Fill = _brush;
            r.Opacity = 1;
            r.IsHitTestVisible = false;
            this.UIElement = r;
        }
    }
}
