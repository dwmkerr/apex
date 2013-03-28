using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Apex.Controls
{
    public class ImageCheckBox : CheckBox
    {
        /// <summary>
        /// Initializes the <see cref="ImageCheckBox"/> class.
        /// </summary>
#if !SILVERLIGHT
        static ImageCheckBox()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageCheckBox), new FrameworkPropertyMetadata(typeof(ImageCheckBox)));
        }
#else
        public ImageCheckBox()
        {
            //  Override the default style.
            DefaultStyleKey = typeof(ImageCheckBox);
        }
#endif
        
        /// <summary>
        /// The DependencyProperty for the CheckedImageSource property.
        /// </summary>
        public static readonly DependencyProperty CheckedImageSourceProperty =
          DependencyProperty.Register("CheckedImageSource", typeof(ImageSource), typeof(ImageCheckBox),
          new PropertyMetadata(default(ImageSource), new PropertyChangedCallback(OnCheckedImageSourceChanged)));

        /// <summary>
        /// Gets or sets CheckedImageSource.
        /// </summary>
        /// <value>The value of CheckedImageSource.</value>
        public ImageSource CheckedImageSource
        {
            get { return (ImageSource)GetValue(CheckedImageSourceProperty); }
            set { SetValue(CheckedImageSourceProperty, value); }
        }

        /// <summary>
        /// Called when CheckedImageSource is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCheckedImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageCheckBox me = o as ImageCheckBox;
        }

        
        /// <summary>
        /// The DependencyProperty for the UncheckedImageSource property.
        /// </summary>
        public static readonly DependencyProperty UncheckedImageSourceProperty =
          DependencyProperty.Register("UncheckedImageSource", typeof(ImageSource), typeof(ImageCheckBox),
          new PropertyMetadata(default(ImageSource), new PropertyChangedCallback(OnUncheckedImageSourceChanged)));

        /// <summary>
        /// Gets or sets UncheckedImageSource.
        /// </summary>
        /// <value>The value of UncheckedImageSource.</value>
        public ImageSource UncheckedImageSource
        {
            get { return (ImageSource)GetValue(UncheckedImageSourceProperty); }
            set { SetValue(UncheckedImageSourceProperty, value); }
        }

        /// <summary>
        /// Called when UncheckedImageSource is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnUncheckedImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
        }
    }
}
