using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Apex.MVVM;

namespace Apex.Helpers.Popups
{
    /// <summary>
    /// The popup animation helper provides the functionality to animate a popup
    /// being shown in a popup host.
    /// </summary>
    public class BounceUpDownPopupAnimationHelper : PopupAnimationHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FadeInOutPopupAnimationHelper"/> class.
        /// </summary>
        public BounceUpDownPopupAnimationHelper()
        {
            //  Set default properties.
            BounceInDuration = new Duration(TimeSpan.FromMilliseconds(400));
            BounceOutDuration = new Duration(TimeSpan.FromMilliseconds(400));
            BounceInDirection = 315;
            BounceOutDirection = 45;
        }

        /// <summary>
        /// Animates the popup show.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popupBackground">The popup background.</param>
        /// <param name="popupElement">The popup element.</param>
        protected override void AnimatePopupShow(Grid popupHost, Grid popupBackground, UIElement popupElement)
        {
            //  Cast the data.
            var popupFrameworkElement = popupElement as FrameworkElement;
            if(popupFrameworkElement == null)
                throw new ArgumentException("To use a Bounce Up and Down popup animation, the popup must be a framework element.");
            
            //  Get a sensible bounce in distance.
            var bounceInDistance = popupHost.ActualHeight + popupHost.ActualWidth;

            //  Get the X/Y values.
            var x = -bounceInDistance * Math.Sin(BounceInDirection * Math.PI / 180);
            var y = bounceInDistance * Math.Cos(BounceInDirection * Math.PI / 180);

            //  Create and set the translation.
            var translation = new TranslateTransform(x, y);
            popupFrameworkElement.RenderTransform = translation;

            //  Initially, the popup background is invisible and the popup top margin is very high.
            popupElement.Opacity = 0;
            popupBackground.Opacity = 0;

            //  Set the background color.
            popupBackground.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            //  Add both invisible elements to the host.
            popupHost.Children.Add(popupBackground);
            popupHost.Children.Add(popupElement);

            //  Now create a storyboard to animate a fade in.
            var storyboard = new Storyboard();
            
            //  Create an animation for the opacity.
            var popupBackgroundOpacityAnimation = new DoubleAnimation(0, 0.5, BounceInDuration);
            var popupTranslateXAnimation = new DoubleAnimation(0, BounceInDuration);
            var popupTranslateYAnimation = new DoubleAnimation(0, BounceInDuration);
            popupTranslateXAnimation.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut, Oscillations = 2, Springiness = 8 };
            popupTranslateYAnimation.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut, Oscillations = 2, Springiness = 8 };
            var popupOpacityAnimation = new DoubleAnimation(0, 1, BounceInDuration);

            //  Set the targets for the animations
            Storyboard.SetTarget(popupBackgroundOpacityAnimation, popupBackground);
            Storyboard.SetTarget(popupTranslateXAnimation, popupFrameworkElement);
            Storyboard.SetTarget(popupTranslateYAnimation, popupFrameworkElement);
            Storyboard.SetTarget(popupOpacityAnimation, popupElement);
            Storyboard.SetTargetProperty(popupBackgroundOpacityAnimation, new PropertyPath(FrameworkElement.OpacityProperty));
            Storyboard.SetTargetProperty(popupTranslateXAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            Storyboard.SetTargetProperty(popupTranslateYAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
            Storyboard.SetTargetProperty(popupOpacityAnimation, new PropertyPath(FrameworkElement.OpacityProperty));

            //  Add the animation to the storyboard.
            storyboard.Children.Add(popupBackgroundOpacityAnimation);
            storyboard.Children.Add(popupTranslateXAnimation);
            storyboard.Children.Add(popupTranslateYAnimation);
            storyboard.Children.Add(popupOpacityAnimation);

            //  Start the storyboard.
            storyboard.Begin(popupHost);
        }

        /// <summary>
        /// Animates the popup hide.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popupBackground">The popup background.</param>
        /// <param name="popupElement">The popup element.</param>
        protected override void AnimatePopupHide(Grid popupHost, Grid popupBackground, UIElement popupElement)
        {
            //  Cast the data.
            var popupFrameworkElement = popupElement as FrameworkElement;
            if (popupFrameworkElement == null)
                throw new ArgumentException("To use a Bounce Up and Down popup animation, the popup must be a framework element.");

            //  Get a sensible bounce in distance.
            var bounceOutDistance = popupHost.ActualHeight + popupHost.ActualWidth;

            //  Get the X/Y values.
            var x = bounceOutDistance * Math.Sin(BounceOutDirection * Math.PI / 180);
            var y = -bounceOutDistance * Math.Cos(BounceOutDirection * Math.PI / 180);
            
            //  Now create a storyboard to animate a fade out.
            var storyboard = new Storyboard();
            
            //  Create an animation for the opacity.
            var popupBackgroundOpacityAnimation = new DoubleAnimation(0, BounceOutDuration);
            var popupOpacityAnimation = new DoubleAnimation(0, BounceOutDuration);
            var popupTranslateXAnimation = new DoubleAnimation(x, BounceOutDuration);
            var popupTranslateYAnimation = new DoubleAnimation(y, BounceOutDuration);
            
            //  Set the targets for the animations
            Storyboard.SetTarget(popupBackgroundOpacityAnimation, popupBackground);
            Storyboard.SetTarget(popupOpacityAnimation, popupElement);
            Storyboard.SetTarget(popupTranslateXAnimation, popupFrameworkElement);
            Storyboard.SetTarget(popupTranslateYAnimation, popupFrameworkElement);
            Storyboard.SetTargetProperty(popupBackgroundOpacityAnimation, new PropertyPath(FrameworkElement.OpacityProperty));
            Storyboard.SetTargetProperty(popupOpacityAnimation, new PropertyPath(FrameworkElement.OpacityProperty));
            Storyboard.SetTargetProperty(popupTranslateXAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            Storyboard.SetTargetProperty(popupTranslateYAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
            
            //  Add the animation to the storyboard.
            storyboard.Children.Add(popupBackgroundOpacityAnimation);
            storyboard.Children.Add(popupOpacityAnimation);
            storyboard.Children.Add(popupTranslateXAnimation);
            storyboard.Children.Add(popupTranslateYAnimation);

            //  When the storyboard is completed, we'll remove the elements from the popup host.
            storyboard.Completed += (sender, args) =>
            {
                //  Remove the popup and background from the host.
                popupHost.Children.Remove(popupBackground);
                popupHost.Children.Remove(popupElement);
            };

            //  Start the storyboard.
            storyboard.Begin(popupHost);
        }

        /// <summary>
        /// The transformation name.
        /// </summary>
        private const string TransformationName = "BounceTransformation";

        /// <summary>
        /// Gets or sets the duration of the bounce in.
        /// </summary>
        /// <value>
        /// The duration of the bounce in.
        /// </value>
        public Duration BounceInDuration { get; set; }

        /// <summary>
        /// Gets or sets the duration of the bounce out.
        /// </summary>
        /// <value>
        /// The duration of the bounce out.
        /// </value>
        public Duration BounceOutDuration { get; set; }

        /// <summary>
        /// Gets or sets the bounce in direction. This is the angle
        /// from the top of the screen in degrees - i.e. 0 bounces in
        /// from the top, 180 from the bottom, etc.
        /// </summary>
        /// <value>
        /// The bounce in direction.
        /// </value>
        public double BounceInDirection { get; set; }

        /// <summary>
        /// Gets or sets the bounce out direction. This is the angle
        /// from the top of the screen in degrees - i.e. 0 bounces out
        /// to the top, 180 to the bottom, etc.
        /// </summary>
        /// <value>
        /// The bounce out direction.
        /// </value>
        public double BounceOutDirection { get; set; }
    }
}
