using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Apex.Adorners
{
    public class Adorner : DependencyObject
    {
        private TranslateTransform translation = new TranslateTransform();

        private static readonly DependencyProperty UIElementProperty =
            DependencyProperty.Register("UIElement", typeof(UIElement), typeof(Adorner),
            new PropertyMetadata(null));

        public TranslateTransform Translation
        {
            get { return translation; }
        }

        public AdornerLayer ParentAdornerLayer
        {
            get;
            set;
        }

        public UIElement UIElement
        {
            get { return (UIElement)GetValue(UIElementProperty); }
            set { SetValue(UIElementProperty, value); }
        }
    }
}
