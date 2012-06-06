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
    public class FadeInOutPopupAnimationHelper : PopupAnimationHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FadeInOutPopupAnimationHelper"/> class.
        /// </summary>
        public FadeInOutPopupAnimationHelper()
        {
            //  Set default properties.
            FadeInDuration = new Duration(TimeSpan.FromMilliseconds(250));
            FadeOutDuration = new Duration(TimeSpan.FromMilliseconds(250));
        }

        /// <summary>
        /// Animates the popup show.
        /// </summary>
        /// <param name="popupHost">The popup host.</param>
        /// <param name="popupBackground">The popup background.</param>
        /// <param name="popupElement">The popup element.</param>
        protected override void AnimatePopupShow(Grid popupHost, Grid popupBackground, UIElement popupElement)
        {
            //  Initially, the popup and it's background are invisible.
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
            var popupBackgroundOpacityAnimation = new DoubleAnimation(0, 0.5, FadeInDuration);
            var popupOpacityAnimation = new DoubleAnimation(0, 1, FadeInDuration);

            //  Set the targets for the animations
            Storyboard.SetTarget(popupBackgroundOpacityAnimation, popupBackground);
            Storyboard.SetTarget(popupOpacityAnimation, popupElement);
            Storyboard.SetTargetProperty(popupBackgroundOpacityAnimation, new PropertyPath("Opacity", 0));
            Storyboard.SetTargetProperty(popupOpacityAnimation, new PropertyPath("Opacity", 0));

            //  Add the animation to the storyboard.
            storyboard.Children.Add(popupBackgroundOpacityAnimation);
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
            //  Now create a storyboard to animate a fade out.
            var storyboard = new Storyboard();
            
            //  Create an animation for the opacity.
            var popupBackgroundOpacityAnimation = new DoubleAnimation(0, FadeOutDuration);
            var popupOpacityAnimation = new DoubleAnimation(0, FadeOutDuration);

            //  Set the targets for the animations
            Storyboard.SetTarget(popupBackgroundOpacityAnimation, popupBackground);
            Storyboard.SetTarget(popupOpacityAnimation, popupElement);
            Storyboard.SetTargetProperty(popupBackgroundOpacityAnimation, new PropertyPath("Opacity", 0));
            Storyboard.SetTargetProperty(popupOpacityAnimation, new PropertyPath("Opacity", 0));

            //  Add the animation to the storyboard.
            storyboard.Children.Add(popupBackgroundOpacityAnimation);
            storyboard.Children.Add(popupOpacityAnimation);

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
        /// Gets or sets the duration of the fade in.
        /// </summary>
        /// <value>
        /// The duration of the fade in.
        /// </value>
        public Duration FadeInDuration { get; set; }

        /// <summary>
        /// Gets or sets the duration of the fade out.
        /// </summary>
        /// <value>
        /// The duration of the fade out.
        /// </value>
        public Duration FadeOutDuration { get; set; }
    }
}
