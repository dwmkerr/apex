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
    /// The MultiBorder control mimics the standard Border control, however, different
    /// values can be set for the brushes and thicknesses for each edge.
    /// </summary>
    public class MultiBorder : ContentControl
    {
        /// <summary>
        /// Initializes the <see cref="MultiBorder"/> class.
        /// </summary>
        static MultiBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (MultiBorder),
                                                     new FrameworkPropertyMetadata(typeof (MultiBorder)));
        }

        /// <summary>
        /// The BorderBrushLeftProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderBrushLeftProperty = DependencyProperty.Register("BorderBrushLeft",
                                                                                               typeof (Brush),
                                                                                               typeof (MultiBorder));

        /// <summary>
        /// The BorderBrushTopProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderBrushTopProperty = DependencyProperty.Register("BorderBrushTop",
                                                                                              typeof (Brush),
                                                                                              typeof (MultiBorder));

        /// <summary>
        /// The BorderBrushRightProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderBrushRightProperty = DependencyProperty.Register("BorderBrushRight",
                                                                                                typeof (Brush),
                                                                                                typeof (MultiBorder));

        /// <summary>
        /// The BorderBrushBottomProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderBrushBottomProperty = DependencyProperty.Register("BorderBrushBottom",
                                                                                                 typeof (Brush),
                                                                                                 typeof (MultiBorder));

        /// <summary>
        /// The BorderThicknessLeftProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderThicknessLeftProperty = DependencyProperty.Register(
            "BorderThicknessLeft", typeof (double), typeof (MultiBorder),
            new PropertyMetadata(1.0));

        /// <summary>
        /// The BorderThicknessTopProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderThicknessTopProperty = DependencyProperty.Register("BorderThicknessTop",
                                                                                                  typeof (double),
                                                                                                  typeof (MultiBorder),
                                                                                                  new PropertyMetadata(
                                                                                                      1.0));

        /// <summary>
        /// The BorderThicknessRightProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderThicknessRightProperty =
            DependencyProperty.Register("BorderThicknessRight", typeof (double), typeof (MultiBorder),
                                        new PropertyMetadata(1.0));

        /// <summary>
        /// The BorderThicknessBottomProperty dependency property.
        /// </summary>
        public static DependencyProperty BorderThicknessBottomProperty =
            DependencyProperty.Register("BorderThicknessBottom", typeof (double), typeof (MultiBorder),
                                        new PropertyMetadata(1.0));

        /// <summary>
        /// Gets or sets the border brush left.
        /// </summary>
        /// <value>
        /// The border brush left.
        /// </value>
        public Brush BorderBrushLeft
        {
            get { return (Brush) GetValue(BorderBrushLeftProperty); }
            set { SetValue(BorderBrushLeftProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border brush top.
        /// </summary>
        /// <value>
        /// The border brush top.
        /// </value>
        public Brush BorderBrushTop
        {
            get { return (Brush) GetValue(BorderBrushTopProperty); }
            set { SetValue(BorderBrushTopProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border brush right.
        /// </summary>
        /// <value>
        /// The border brush right.
        /// </value>
        public Brush BorderBrushRight
        {
            get { return (Brush) GetValue(BorderBrushRightProperty); }
            set { SetValue(BorderBrushRightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border brush bottom.
        /// </summary>
        /// <value>
        /// The border brush bottom.
        /// </value>
        public Brush BorderBrushBottom
        {
            get { return (Brush) GetValue(BorderBrushBottomProperty); }
            set { SetValue(BorderBrushBottomProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border thickness left.
        /// </summary>
        /// <value>
        /// The border thickness left.
        /// </value>
        public double BorderThicknessLeft
        {
            get { return (double) GetValue(BorderThicknessLeftProperty); }
            set { SetValue(BorderThicknessLeftProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border thickness top.
        /// </summary>
        /// <value>
        /// The border thickness top.
        /// </value>
        public double BorderThicknessTop
        {
            get { return (double) GetValue(BorderThicknessTopProperty); }
            set { SetValue(BorderThicknessTopProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border thickness right.
        /// </summary>
        /// <value>
        /// The border thickness right.
        /// </value>
        public double BorderThicknessRight
        {
            get { return (double) GetValue(BorderThicknessRightProperty); }
            set { SetValue(BorderThicknessRightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border thickness bottom.
        /// </summary>
        /// <value>
        /// The border thickness bottom.
        /// </value>
        public double BorderThicknessBottom
        {
            get { return (double) GetValue(BorderThicknessBottomProperty); }
            set { SetValue(BorderThicknessBottomProperty, value); }
        }
    }
}