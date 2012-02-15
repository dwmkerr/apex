using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Apex.Extensions;

namespace Apex.Adorners 
{
    public class UIElementAdorner : Adorner
    {
        public UIElementAdorner(UIElement uiElement)
        {
            this.UIElement = uiElement;
        }
    }
}
