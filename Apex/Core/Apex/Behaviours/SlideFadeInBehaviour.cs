using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Apex.Extensions;

namespace Apex.Behaviours
{
    /// <summary>
    /// The Slide Fade In behaviour does an MS Zune style slide and fade in.
    /// </summary>
    public class SlideFadeInBehaviour : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        public static void DoSlideFadeIn(UIElement container)
        {
            //  We're going to fill a list with slide fade in behaviours.
            var slideFadeInBehaviours = new List<SlideFadeInBehaviour>();

            //  Get all children.
            var children = container.GetChildren<UIElement>();

            //  Go through each child.
            foreach(var child in children)
            {
                //  Get the behaviours.
                var behaviours = Interaction.GetBehaviors(child);

                //  Do we have an slide fade in behaviours?
                slideFadeInBehaviours.AddRange( from b in behaviours where );
            }
        }

        public IEnumerable<Timeline> CreateAnimations()
        {
            //  Create and set the translation.
            var translation = new TranslateTransform() { X = -SlideDistance, Y = 0 };
            AssociatedObject.RenderTransform = translation;

            //  Create an animation for the opacity.
            var opacityAnimation = new DoubleAnimation() { From = 0, To = 1, Duration = Duration };

            //  Create an animation for the slide in.
            var slideInAnimation = new DoubleAnimation() { To = 0, Duration = Duration };
            slideInAnimation.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut, Oscillations = 2, Springiness = 8 };

            //  Set the targets for the animations.
            Storyboard.SetTarget(opacityAnimation, AssociatedObject);
            Storyboard.SetTarget(slideInAnimation, AssociatedObject);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTargetProperty(slideInAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            //  Return the animations.
            return new List<Timeline> {opacityAnimation, slideInAnimation};
        }

        private const double SlideDistance = 40.0;

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(SlideFadeInBehaviour), 
            new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(750))));

        public Duration Duration
        {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }
    }
}
