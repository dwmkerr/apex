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
using System.Windows.Shapes;
using System.ComponentModel;

namespace Apex.Controls
{
    /// <summary>
    /// The PaddedGrid control is a Grid that supports padding.
    /// </summary>
    public class PaddedGrid : ApexGrid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaddedGrid"/> class.
        /// </summary>
        public PaddedGrid()
        {
            //  Add a loded event handler.
            Loaded += new RoutedEventHandler(PaddedGrid_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the PaddedGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void PaddedGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //  Get the number of children.
            int childCount = VisualTreeHelper.GetChildrenCount(this);

            //  Go through the children.
            for (int i = 0; i < childCount; i++)
            {
                //  Get the child.
                DependencyObject child = VisualTreeHelper.GetChild(this, i);
              
                //  Create the binding.
                Binding binding = new Binding();
                binding.Source = this;
                binding.Path = new PropertyPath("Padding");

                //  Bind the child's margin to the grid's padding.
                BindingOperations.SetBinding(child, FrameworkElement.MarginProperty, binding);
            }
        }
      
        /// <summary>
        /// Called when the padding changes.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnPaddingChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
          //  Get the padded grid that has had its padding changed.
          PaddedGrid me = dependencyObject as PaddedGrid;
          if (me != null)
          {
            //  Use an explicit 'InvalidateArrange', rather than the AffectsMeasure FrameworkPropertyMetadataOptions flag
            //  as these flags aren't available in Silverlight - this method will work in SL and WPF.
            me.InvalidateArrange();
          } 
        }

        /// <summary>
        /// The internal dependency property object for the 'Padding' property.
        /// </summary>
#if !SILVERLIGHT
        private static readonly DependencyProperty PaddingProperty =
          DependencyProperty.Register("Padding", typeof(Thickness), typeof(PaddedGrid),
          new FrameworkPropertyMetadata(new Thickness(0.0), 
              FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(OnPaddingChanged)));
#else
        private static readonly DependencyProperty PaddingProperty =
          DependencyProperty.Register("Padding", typeof(Thickness), typeof(PaddedGrid),
          new PropertyMetadata(new Thickness(0.0),  new PropertyChangedCallback(OnPaddingChanged)));
#endif

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        /// <value>The padding.</value>
        [Description("The padding property."), Category("Common Properties")]
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
    }
}