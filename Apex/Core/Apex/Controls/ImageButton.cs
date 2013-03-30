using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Apex.Controls
{
    /// <summary>
    /// The image button is a button that shows an image which is changed for mouseover.
    /// </summary>
    public class ImageButton : Button
    {
        /// <summary>
        /// Initializes the <see cref="ImageButton"/> class.
        /// </summary>
#if !SILVERLIGHT
        static ImageButton()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }
#else
        public ImageButton()
        {
            //  Override the default style.
            DefaultStyleKey = typeof(ImageButton);
        }
#endif

        /// <summary>
        /// The DependencyProperty for the NormalImageSource property.
        /// </summary>
        public static readonly DependencyProperty NormalImageSourceProperty =
          DependencyProperty.Register("NormalImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource)));

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
        /// The DependencyProperty for the MouseOverImageSource property.
        /// </summary>
        public static readonly DependencyProperty MouseOverImageSourceProperty =
          DependencyProperty.Register("MouseOverImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource)));

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
        /// The DependencyProperty for the PressedImageSource property.
        /// </summary>
        public static readonly DependencyProperty PressedImageSourceProperty =
          DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource)));

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
        /// The DependencyProperty for the DisabledImageSource property.
        /// </summary>
        public static readonly DependencyProperty DisabledImageSourceProperty =
          DependencyProperty.Register("DisabledImageSource", typeof(ImageSource), typeof(ImageButton),
          new PropertyMetadata(default(ImageSource)));

        /// <summary>
        /// Gets or sets DisabledImageSource.
        /// </summary>
        /// <value>The value of DisabledImageSource.</value>
        public ImageSource DisabledImageSource
        {
            get { return (ImageSource)GetValue(DisabledImageSourceProperty); }
            set { SetValue(DisabledImageSourceProperty, value); }
        }
    }
}
