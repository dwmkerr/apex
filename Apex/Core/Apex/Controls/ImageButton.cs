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
    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        /// <summary>
        /// The DependencyProperty for the NormalImageSource property.
        /// </summary>
        public static readonly DependencyProperty NormalImageSourceProperty =
          DependencyProperty.Register("NormalImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource), new PropertyChangedCallback(OnNormalImageSourceChanged)));

        /// <summary>
        /// Gets or sets NormalImageSource.
        /// </summary>
        /// <value>The value of NormalImageSource.</value>
        public ImageSource NormalImageSource
        {
            get { return (ImageSource)GetValue(NormalImageSourceProperty); }
            set { SetValue(NormalImageSourceProperty, value); }
        }

        /// <summary>
        /// Called when NormalImageSource is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnNormalImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageButton me = o as ImageButton;
        }

        
        /// <summary>
        /// The DependencyProperty for the MouseOverImageSource property.
        /// </summary>
        public static readonly DependencyProperty MouseOverImageSourceProperty =
          DependencyProperty.Register("MouseOverImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource), new PropertyChangedCallback(OnMouseOverImageSourceChanged)));

        /// <summary>
        /// Gets or sets MouseOverImageSource.
        /// </summary>
        /// <value>The value of MouseOverImageSource.</value>
        public ImageSource MouseOverImageSource
        {
            get { return (ImageSource)GetValue(MouseOverImageSourceProperty); }
            set { SetValue(MouseOverImageSourceProperty, value); }
        }

        /// <summary>
        /// Called when MouseOverImageSource is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnMouseOverImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageButton me = o as ImageButton;
        }
        
        /// <summary>
        /// The DependencyProperty for the PressedImageSource property.
        /// </summary>
        public static readonly DependencyProperty PressedImageSourceProperty =
          DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource), new PropertyChangedCallback(OnPressedImageSourceChanged)));

        /// <summary>
        /// Gets or sets PressedImageSource.
        /// </summary>
        /// <value>The value of PressedImageSource.</value>
        public ImageSource PressedImageSource
        {
            get { return (ImageSource)GetValue(PressedImageSourceProperty); }
            set { SetValue(PressedImageSourceProperty, value); }
        }

        /// <summary>
        /// Called when PressedImageSource is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnPressedImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageButton me = o as ImageButton;
        }
        
        /// <summary>
        /// The DependencyProperty for the DisabledImageSource property.
        /// </summary>
        public static readonly DependencyProperty DisabledImageSourceProperty =
          DependencyProperty.Register("DisabledImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource), new PropertyChangedCallback(OnDisabledImageSourceChanged)));

        /// <summary>
        /// Gets or sets DisabledImageSource.
        /// </summary>
        /// <value>The value of DisabledImageSource.</value>
        public ImageSource DisabledImageSource
        {
            get { return (ImageSource)GetValue(DisabledImageSourceProperty); }
            set { SetValue(DisabledImageSourceProperty, value); }
        }

        /// <summary>
        /// Called when DisabledImageSource is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDisabledImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageButton me = o as ImageButton;
        }
    }
}
