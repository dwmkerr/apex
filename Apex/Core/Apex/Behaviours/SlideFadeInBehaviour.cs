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
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Opacity = 0;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        /// <summary>
        /// Performs the slide fade in of all elements contained in 'container'
        /// that have the SlideFadeInBehaviour.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void DoSlideFadeIn(FrameworkElement container)
        {
            //  We're going to fill a list with slide fade in behaviours.
            var slideFadeInBehaviours = new List<SlideFadeInBehaviour>();

            //  Get all children.
            var children = container.GetLogicalChildren<UIElement>();

            //  Go through each child, add all slide fade in behaviours.
            foreach (var child in children)
            {
                //  Do we have an slide fade in behaviours?
                slideFadeInBehaviours.AddRange(
                    from b in Interaction.GetBehaviors(child)
                    where b is SlideFadeInBehaviour
                    select b as SlideFadeInBehaviour);
            }

            //  Create the animation for each fade in.
            var animations = slideFadeInBehaviours.SelectMany(s => s.CreateAnimations());

            //  Create a storyboard, add the animations.
            var storyboard = new Storyboard();
            foreach (var animation in animations)
                storyboard.Children.Add(animation);

            //  Start the storyboard.
#if !SILVERLIGHT
            storyboard.Begin(container);
#else
            storyboard.Begin();
#endif
        }

        /// <summary>
        /// Creates the animations required to slide fade in this element.
        /// </summary>
        /// <returns>Required animations.</returns>
        private IEnumerable<Timeline> CreateAnimations()
        {
            //  Create and set the translation.
            var translation = new TranslateTransform() { X = -SlideDistance, Y = 0 };
            AssociatedObject.RenderTransform = translation;

            //  Create an animation for the opacity.
            var opacityAnimation = new DoubleAnimation() { From = 0, To = 1, Duration = Duration, BeginTime = BeginTime};

            //  Create an animation for the slide in.
            var slideInAnimation = new DoubleAnimation() { To = 0, Duration = Duration, BeginTime = BeginTime };
            slideInAnimation.EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut };

            //  Set the targets for the animations.
            Storyboard.SetTarget(opacityAnimation, AssociatedObject);
            Storyboard.SetTarget(slideInAnimation, AssociatedObject);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTargetProperty(slideInAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            //  Return the animations.
            return new List<Timeline> { opacityAnimation, slideInAnimation };
        }

        private const double SlideDistance = 40.0;

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(SlideFadeInBehaviour),
            new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(750))));

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the BeginTime property.
        /// </summary>
        private static readonly DependencyProperty BeginTimeProperty =
          DependencyProperty.Register("BeginTime", typeof(TimeSpan), typeof(SlideFadeInBehaviour),
          new PropertyMetadata(TimeSpan.FromMilliseconds(0)));

        /// <summary>
        /// Gets or sets BeginTime.
        /// </summary>
        /// <value>The value of BeginTime.</value>
        public TimeSpan BeginTime
        {
            get { return (TimeSpan)GetValue(BeginTimeProperty); }
            set { SetValue(BeginTimeProperty, value); }
        }
    }
}
