using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Apex.Extensions;

namespace Apex.Adorners
{
    /// <summary>
    /// Interaction logic for AdornerLayer.xaml
    /// </summary>
    public partial class AdornerLayer : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdornerLayer"/> class.
        /// </summary>
        public AdornerLayer()
        {
            InitializeComponent();

            IsHitTestVisible = false;
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //  Get the top level ancestor.
            DependencyObject tla = this.GetTopLevelParent();

            //  Update the dictionary.
            if(adornerLayers.ContainsKey(tla) == false)
                adornerLayers.Add(tla, this);
        }

        /// <summary>
        /// Gets the adorner layer.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static AdornerLayer GetAdornerLayer(DependencyObject obj)
        {
            //  Get the top level ancestor.
            DependencyObject tla = obj.GetTopLevelParent();
            if (adornerLayers.ContainsKey(tla))
                return adornerLayers[tla];
            return null;
        }

        private static readonly Dictionary<DependencyObject, AdornerLayer> adornerLayers =
            new Dictionary<DependencyObject, AdornerLayer>();

        /// <summary>
        /// Adds the adorner.
        /// </summary>
        /// <param name="adorner">The adorner.</param>
        public void AddAdorner(Adorner adorner)
        {
            adorner.ParentAdornerLayer = this;
            adorner.UIElement.RenderTransform = adorner.Translation;

            adornerCanvas.Children.Add(adorner.UIElement);
        }

        /// <summary>
        /// Removes the adorner.
        /// </summary>
        /// <param name="adorner">The adorner.</param>
        public void RemoveAdorner(Adorner adorner)
        {
            adornerCanvas.Children.Remove(adorner.UIElement);
        }
    }
}
