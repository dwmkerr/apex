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
using System.ComponentModel;
using Apex.MVVM;
using System.Windows.Media.Animation;

namespace Apex.Controls
{

  /// <summary>
  /// The Flip Panel Control. A control that hosts content on the front and back of the panel,
  /// and allows the panel to be flipped - revealing the other side.
  /// </summary>
  public class FlipPanel : Control
  {
    /// <summary>
    /// Initializes the <see cref="FlipPanel"/> class.
    /// </summary>
    static FlipPanel()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel), new FrameworkPropertyMetadata(typeof(FlipPanel)));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FlipPanel"/> class.
    /// </summary>
    public FlipPanel()
    {
      //  Keep track of size changed events.
      SizeChanged += new SizeChangedEventHandler(FlipPanel_SizeChanged);

        //  Create the Flip command.
      flipCommand = new Command(Flip, true);
    }
      
    /// <summary>
    /// Handles the SizeChanged event of the FlipPanel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.SizeChangedEventArgs"/> instance containing the event data.</param>
    void FlipPanel_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      //  To make sure that the 3D model is not distorted when we resize, update the aspect ratio.
      AspectRatio = (double)(ActualHeight / ActualWidth);
    }

    /// <summary>
    /// Flips this instance.
    /// </summary>
    private void Flip()
    {
        if (IsFlipped)
        {
            RoutedEventArgs args = new RoutedEventArgs(FlippedBackToFrontEvent);
            RaiseEvent(args);
            IsFlipped = false;
        }
        else
        {
            RoutedEventArgs args = new RoutedEventArgs(FlippedFrontToBackEvent);
            RaiseEvent(args);
            IsFlipped = true;
        }
    }

    /// <summary>
    /// The ContentFront dependency property.
    /// </summary>
    public static readonly DependencyProperty ContentFrontProperty = DependencyProperty.Register("ContentFront", typeof(object), typeof(FlipPanel));

    /// <summary>
    /// The ContentBack dependency property.
    /// </summary>
    public static readonly DependencyProperty ContentBackProperty = DependencyProperty.Register("ContentBack", typeof(object), typeof(FlipPanel));

    /// <summary>
    /// The AspectRatio dependency property.
    /// </summary>
    public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(FlipPanel), new PropertyMetadata(0.5));

    /// <summary>
    /// The IsFlipped property, true if the panel is flipped.
    /// </summary>
    public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipPanel), new PropertyMetadata(false));
      
    /// <summary>
    /// Occurs when flipped front to back.
    /// </summary>
    public static readonly RoutedEvent FlippedFrontToBackEvent = EventManager.RegisterRoutedEvent("FlippedFrontToBack", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FlipPanel));

    /// <summary>
    /// Occurs when flipped back to front.
    /// </summary>
      public static readonly RoutedEvent FlippedBackToFrontEvent = EventManager.RegisterRoutedEvent("FlippedBackToFront", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FlipPanel));

    /// <summary>
    /// The Flip Command.
    /// </summary>
    public Command flipCommand;

    /// <summary>
    /// Gets or sets the front content.
    /// </summary>
    /// <value>The front content.</value>
    public object ContentFront
    {
      get { return GetValue(ContentFrontProperty); }
      set { SetValue(ContentFrontProperty, value); }
    }

    /// <summary>
    /// Gets or sets the back content.
    /// </summary>
    /// <value>The back content.</value>
    public object ContentBack
    {
      get { return GetValue(ContentBackProperty); }
      set { SetValue(ContentBackProperty, value); }
    }

    /// <summary>
    /// Gets or sets the aspect ratio.
    /// </summary>
    /// <value>The aspect ratio.</value>
    public double AspectRatio
    {
      get { return (float)GetValue(AspectRatioProperty); }
      set { SetValue(AspectRatioProperty, value); }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is flipped.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is flipped; otherwise, <c>false</c>.
    /// </value>
    public bool IsFlipped
    {
        get { return (bool)GetValue(IsFlippedProperty); }
        set { SetValue(IsFlippedProperty, value); }
    }

    /// <summary>
    /// Gets the flip command.
    /// </summary>
    /// <value>The flip command.</value>
    public Command FlipCommand
    {
        get { return flipCommand; }
    }

    /// <summary>
    /// Occurs when flipped front to back.
    /// </summary>
    public event RoutedEventHandler FlippedFrontToBack
    {
        add { AddHandler(FlippedFrontToBackEvent, value); }
        remove { RemoveHandler(FlippedFrontToBackEvent, value); }
    }

    /// <summary>
    /// Occurs when flipped back to fron.
    /// </summary>
    public event RoutedEventHandler FlippedBackToFront
    {
        add { AddHandler(FlippedBackToFrontEvent, value); }
        remove { RemoveHandler(FlippedBackToFrontEvent, value); }
    }
  }
}
