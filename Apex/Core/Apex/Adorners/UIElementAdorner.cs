using System.Windows;

namespace Apex.Adorners 
{
    /// <summary>
    /// Adorner for a UI element.
    /// </summary>
    public class UIElementAdorner : Adorner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIElementAdorner"/> class.
        /// </summary>
        /// <param name="uiElement">The UI element.</param>
        public UIElementAdorner(UIElement uiElement)
        {
            UIElement = uiElement;
        }
    }
}
