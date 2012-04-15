using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Apex.Extensions;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections;
using Apex.Adorners;

namespace Apex.DragAndDrop
{
    /// <summary>
    /// The DragAndDrop class is a singleton object that handles drag and drop in an
    /// application.
    /// </summary>
    public static class DragAndDrop
    {
        /// <summary>
        /// The 'IsDragSource' dependency property.
        /// </summary>
        public static readonly DependencyProperty IsDragSourceProperty = 
          DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(FrameworkElement),
          new PropertyMetadata(false));

        /// <summary>
        /// Gets the 'IsDragSource' property.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>The 'IsDragSource' property</returns>
        public static bool GetIsDragSource(FrameworkElement o)
        {
          return (bool)o.GetValue(IsDragSourceProperty);
        }

        /// <summary>
        /// Sets the 'IsDragSource' property.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetIsDragSource(FrameworkElement o, bool value)
        {
          o.SetValue(IsDragSourceProperty, value);
        }

        /// <summary>
        /// The 'IsDropTarget' property.
        /// </summary>
        private static readonly DependencyProperty IsDropTargetProperty =
          DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(FrameworkElement),
          new PropertyMetadata(false));

        /// <summary>
        /// Gets the 'IsDropTarget' property.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>The 'IsDropTarget' property.</returns>
        public static bool GetIsDropTarget(FrameworkElement o)
        {
            return (bool)o.GetValue(IsDropTargetProperty);
        }

        /// <summary>
        /// Sets the 'IsDropTarget' property.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetIsDropTarget(FrameworkElement o, bool value)
        {
            o.SetValue(IsDropTargetProperty, value);
        }

        /// <summary>
        /// The 'IsDraggable' property.
        /// </summary>
        private static readonly DependencyProperty IsDraggableProperty =
          DependencyProperty.RegisterAttached("IsDraggable", typeof(bool), typeof(FrameworkElement),
          new PropertyMetadata(false));

        /// <summary>
        /// Gets the 'IsDraggable' property.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>The 'IsDraggable' property.</returns>
        public static bool GetIsDraggable(DependencyObject o)
        {
            return (bool)o.GetValue(IsDraggableProperty);
        }

        /// <summary>
        /// Sets the 'IsDraggable' property.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetIsDraggable(DependencyObject o, bool value)
        {
            o.SetValue(IsDraggableProperty, value);
        }
    }

}
