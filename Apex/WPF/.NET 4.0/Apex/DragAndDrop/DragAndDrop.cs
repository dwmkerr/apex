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
        private static readonly DependencyProperty IsDragSourceProperty = 
          DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(FrameworkElement),
          new PropertyMetadata(false));

        public static bool GetIsDragSource(FrameworkElement o)
        {
          return (bool)o.GetValue(IsDragSourceProperty);
        }

        public static void SetIsDragSource(FrameworkElement o, bool value)
        {
          o.SetValue(IsDragSourceProperty, value);
        }

        private static readonly DependencyProperty IsDropTargetProperty =
          DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(FrameworkElement),
          new PropertyMetadata(false));

        public static bool GetIsDropTarget(FrameworkElement o)
        {
            return (bool)o.GetValue(IsDropTargetProperty);
        }

        public static void SetIsDropTarget(FrameworkElement o, bool value)
        {
            o.SetValue(IsDropTargetProperty, value);
        }

        private static readonly DependencyProperty IsDraggableProperty =
          DependencyProperty.RegisterAttached("IsDraggable", typeof(bool), typeof(FrameworkElement),
          new PropertyMetadata(false));

        public static bool GetIsDraggable(DependencyObject o)
        {
            return (bool)o.GetValue(IsDraggableProperty);
        }

        public static void SetIsDraggable(DependencyObject o, bool value)
        {
            o.SetValue(IsDraggableProperty, value);
        }
    }

}
