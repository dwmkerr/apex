using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Apex.Controls
{
  /// <summary>
  /// The Cross Button is a very simple version of the button that displays as a discrete cross,
  /// similar to the buttons at the top of Google Chrome's tabs.
  /// </summary>
    public class CrossButton : Button
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes the <see cref="CrossButton"/> class.
        /// </summary>
        static CrossButton()
        {
          //  Set the style key, so that our control template is used.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CrossButton), new FrameworkPropertyMetadata(typeof(CrossButton)));
        }
#else        
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossButton"/> class.
        /// </summary>
        public CrossButton()
        {
            this.DefaultStyleKey = typeof(CrossButton);
        }
#endif

        /// <summary>
        /// The DependencyProperty for the NormalBackgroundBrush property.
        /// </summary>
        public static readonly DependencyProperty NormalBackgroundBrushProperty =
          DependencyProperty.Register("NormalBackgroundBrush", typeof(Brush), typeof(CrossButton),
          new PropertyMetadata(new SolidColorBrush(Consistency.ColorConverter.ConvertFromString("#00000000"))));

        /// <summary>
        /// Gets or sets NormalBackgroundBrush.
        /// </summary>
        /// <value>The value of NormalBackgroundBrush.</value>
        public Brush NormalBackgroundBrush
        {
            get { return (Brush)GetValue(NormalBackgroundBrushProperty); }
            set { SetValue(NormalBackgroundBrushProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the NormalCrossBrush property.
        /// </summary>
        public static readonly DependencyProperty NormalCrossBrushProperty =
          DependencyProperty.Register("NormalCrossBrush", typeof(Brush), typeof(CrossButton),
          new PropertyMetadata(new SolidColorBrush(Consistency.ColorConverter.ConvertFromString("#FF8f949b"))));

        /// <summary>
        /// Gets or sets NormalCrossBrush.
        /// </summary>
        /// <value>The value of NormalCrossBrush.</value>
        public Brush NormalCrossBrush
        {
            get { return (Brush)GetValue(NormalCrossBrushProperty); }
            set { SetValue(NormalCrossBrushProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the HoverBackgroundBrush property.
        /// </summary>
        public static readonly DependencyProperty HoverBackgroundBrushProperty =
          DependencyProperty.Register("HoverBackgroundBrush", typeof(Brush), typeof(CrossButton),
          new PropertyMetadata(new SolidColorBrush(Consistency.ColorConverter.ConvertFromString("#FFc13535"))));

        /// <summary>
        /// Gets or sets HoverBackgroundBrush.
        /// </summary>
        /// <value>The value of HoverBackgroundBrush.</value>
        public Brush HoverBackgroundBrush
        {
            get { return (Brush)GetValue(HoverBackgroundBrushProperty); }
            set { SetValue(HoverBackgroundBrushProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the HoverCrossBrush property.
        /// </summary>
        public static readonly DependencyProperty HoverCrossBrushProperty =
          DependencyProperty.Register("HoverCrossBrush", typeof(Brush), typeof(CrossButton),
          new PropertyMetadata(new SolidColorBrush(Consistency.ColorConverter.ConvertFromString("#FFf9ebeb"))));

        /// <summary>
        /// Gets or sets HoverCrossBrush.
        /// </summary>
        /// <value>The value of HoverCrossBrush.</value>
        public Brush HoverCrossBrush
        {
            get { return (Brush)GetValue(HoverCrossBrushProperty); }
            set { SetValue(HoverCrossBrushProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the PressedBackgroundBrush property.
        /// </summary>
        public static readonly DependencyProperty PressedBackgroundBrushProperty =
          DependencyProperty.Register("PressedBackgroundBrush", typeof(Brush), typeof(CrossButton),
          new PropertyMetadata(new SolidColorBrush(Consistency.ColorConverter.ConvertFromString("#FF431e20"))));

        /// <summary>
        /// Gets or sets PressedBackgroundBrush.
        /// </summary>
        /// <value>The value of PressedBackgroundBrush.</value>
        public Brush PressedBackgroundBrush
        {
            get { return (Brush)GetValue(PressedBackgroundBrushProperty); }
            set { SetValue(PressedBackgroundBrushProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the PressedCrossBrush property.
        /// </summary>
        public static readonly DependencyProperty PressedCrossBrushProperty =
          DependencyProperty.Register("PressedCrossBrush", typeof(Brush), typeof(CrossButton),
          new PropertyMetadata(new SolidColorBrush(Consistency.ColorConverter.ConvertFromString("#FFf9ebeb"))));

        /// <summary>
        /// Gets or sets PressedCrossBrush.
        /// </summary>
        /// <value>The value of PressedCrossBrush.</value>
        public Brush PressedCrossBrush
        {
            get { return (Brush)GetValue(PressedCrossBrushProperty); }
            set { SetValue(PressedCrossBrushProperty, value); }
        }
    }
}
