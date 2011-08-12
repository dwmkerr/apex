using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Apex.Adorners
{
  /// <summary>
  /// The adorner class is used a base for any kind of adornment of a UI element via
  /// the AdornerLayer.
  /// </summary>
    public class Adorner : DependencyObject
    {
      /// <summary>
      /// The translation used to position the adorner.
      /// </summary>
        private TranslateTransform translation = new TranslateTransform();

        /// <summary>
        /// The UI Element being Adorned.
        /// </summary>
        private static readonly DependencyProperty UIElementProperty =
            DependencyProperty.Register("UIElement", typeof(UIElement), typeof(Adorner),
            new PropertyMetadata(null));

        /// <summary>
        /// Gets the translation.
        /// </summary>
        public TranslateTransform Translation
        {
            get { return translation; }
        }

        /// <summary>
        /// Gets or sets the parent adorner layer.
        /// </summary>
        /// <value>
        /// The parent adorner layer.
        /// </value>
        public AdornerLayer ParentAdornerLayer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the UI element.
        /// </summary>
        /// <value>
        /// The UI element.
        /// </value>
        public UIElement UIElement
        {
            get { return (UIElement)GetValue(UIElementProperty); }
            set { SetValue(UIElementProperty, value); }
        }
    }
}
