using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Apex.Controls;
using Apex.Extensions;

namespace Apex.Behaviours
{
    /// <summary>
    /// The SmoothScrollingBehaviour can be applied to a scrollviewer, and
    /// adds two dependency properties, SmoothHorizontalOffset and SmoothVerticalOffset.
    /// These are fully functional and affect the ScrollViewer's actual offsets. As they
    /// are read/write dependency properties, they can be animated, allowing the scroll
    /// viewer to be very smooth.
    /// </summary>
    public class SmoothScrollingBehaviour : Behavior<ScrollViewer>
    {
        /// <summary>
        /// Smooth scroll to the specified position.
        /// </summary>
        /// <param name="horizontalPosition">The horizontal position.</param>
        /// <param name="verticalPosition">The vertical position.</param>
        public void SmoothScroll(double? horizontalPosition, double? verticalPosition)
        {
            //  Create the storyboard.
            var storyBoard = new Storyboard();

            //  If we have a horizontal position, create the animation for it.
            if (horizontalPosition.HasValue)
            {
                var horzAnim = new DoubleAnimation()
                                   {
                                       To = horizontalPosition.Value,
                                       DecelerationRatio = 0.8,
                                       Duration = TimeSpan.FromMilliseconds(300)
                                   };

                storyBoard.Children.Add(horzAnim);

                Storyboard.SetTarget(horzAnim, this);
                Storyboard.SetTargetProperty(horzAnim, new PropertyPath(SmoothHorizonalOffsetProperty));
            }

            //  If we have a vertical position, create the animation for it.
            if (verticalPosition.HasValue)
            {
                var vertAnim = new DoubleAnimation()
                {
                    To = verticalPosition.Value,
                    DecelerationRatio = 0.8,
                    Duration = TimeSpan.FromMilliseconds(300)
                };

                storyBoard.Children.Add(vertAnim);

                Storyboard.SetTarget(vertAnim, this);
                Storyboard.SetTargetProperty(vertAnim, new PropertyPath(SmoothVerticalOffsetProperty));
            }

            storyBoard.Begin();


        }

        /// <summary>
        /// Called when smooth vertical offset changed.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnSmoothVerticalOffsetChanged(DependencyPropertyChangedEventArgs e)
        {
            AssociatedObject.ScrollToVerticalOffset((double)e.NewValue);
        }
        
        /// <summary>
        /// Called when smooth horizontal offset changed.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnSmoothHorizonalOffsetChanged(DependencyPropertyChangedEventArgs e)
        {
            AssociatedObject.ScrollToHorizontalOffset((double)e.NewValue);
        }

        /// <summary>
        /// Called when smooth vertical offset changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSmoothVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = d as SmoothScrollingBehaviour;
            if(me != null)
                me.OnSmoothVerticalOffsetChanged(e);
        }

        /// <summary>
        /// Called when smooth horizonal offset changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSmoothHorizonalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = d as SmoothScrollingBehaviour;
            if (me != null)
                me.OnSmoothHorizonalOffsetChanged(e);
        }

        /// <summary>
        /// The SmoothVerticalOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty SmoothVerticalOffsetProperty = 
            DependencyProperty.Register("SmoothVerticalOffset", typeof(double),
            typeof(SmoothScrollingBehaviour), new PropertyMetadata(new PropertyChangedCallback(OnSmoothVerticalOffsetChanged)));

        /// <summary>
        /// The SmoothHorizontalOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty SmoothHorizonalOffsetProperty = 
            DependencyProperty.Register("SmoothHorizonalOffset", typeof(double),
            typeof(SmoothScrollingBehaviour), new PropertyMetadata(new PropertyChangedCallback(OnSmoothHorizonalOffsetChanged)));

        /// <summary>
        /// Gets or sets the smooth horizonal offset.
        /// </summary>
        /// <value>
        /// The smooth horizonal offset.
        /// </value>
        public double SmoothHorizonalOffset
        {
            get { return (double)GetValue(SmoothHorizonalOffsetProperty); }
            set { SetValue(SmoothHorizonalOffsetProperty, value); }
        }

        /// <summary>
        /// Gets or sets the smooth vertical offset.
        /// </summary>
        /// <value>
        /// The smooth vertical offset.
        /// </value>
        public double SmoothVerticalOffset
        {
            get { return (double)GetValue(SmoothVerticalOffsetProperty); }
            set { SetValue(SmoothVerticalOffsetProperty, value); }
        }
    }
}
