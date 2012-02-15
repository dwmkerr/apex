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
using System.Collections.ObjectModel;
using Apex.Extensions;

namespace Apex.Adorners
{
    /// <summary>
    /// Interaction logic for AdornerLayer.xaml
    /// </summary>
    public partial class AdornerLayer : UserControl
    {
        public AdornerLayer()
        {
            InitializeComponent();

            IsHitTestVisible = false;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //  Get the top level ancestor.
            DependencyObject tla = this.GetTopLevelParent();

            //  Update the dictionary.
            if(adornerLayers.ContainsKey(tla) == false)
                adornerLayers.Add(tla, this);
        }

        public static AdornerLayer GetAdornerLayer(DependencyObject obj)
        {
            //  Get the top level ancestor.
            DependencyObject tla = obj.GetTopLevelParent();
            if (adornerLayers.ContainsKey(tla))
                return adornerLayers[tla];
            return null;
        }

        private static Dictionary<DependencyObject, AdornerLayer> adornerLayers =
            new Dictionary<DependencyObject, AdornerLayer>();

        public void AddAdorner(Adorner adorner)
        {
            adorner.ParentAdornerLayer = this;
            adorner.UIElement.RenderTransform = adorner.Translation;

            adornerCanvas.Children.Add(adorner.UIElement);
        }

        public void RemoveAdorner(Adorner adorner)
        {
            adornerCanvas.Children.Remove(adorner.UIElement);
        }
    }
}
