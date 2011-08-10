using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;


namespace Apex.Commands
{
    public static class ExtendedCommands
    {
      
        public static readonly DependencyProperty ContextMenuDataContextProperty =
            DependencyProperty.RegisterAttached("ContextMenuDataContext",
            typeof(object), typeof(ExtendedCommands),
            new UIPropertyMetadata(OnContextMenuDataContextChanged));

        public static object GetContextMenuDataContext(FrameworkElement obj)
        {
            return obj.GetValue(ContextMenuDataContextProperty);
        }

        public static void SetContextMenuDataContext(FrameworkElement obj, object value)
        {
            obj.SetValue(ContextMenuDataContextProperty, value);
        }

        private static void OnContextMenuDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = d as FrameworkElement;
            if (frameworkElement == null)
                return;

            if (frameworkElement.ContextMenu != null)
                frameworkElement.ContextMenu.DataContext = GetContextMenuDataContext(frameworkElement);
        }

        private static void Control_LeftClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (e.ClickCount != 1 || e.LeftButton != MouseButtonState.Pressed || element == null)
                return;

            ICommand command = GetLeftClickCommand(element);
            object param = GetLeftClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        private static void Control_RightClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (e.ClickCount != 1 || e.RightButton != MouseButtonState.Pressed || element == null)
                return;

            ICommand command = GetRightClickCommand(element);
            object param = GetRightClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        private static void Control_LeftDoubleClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (e.ClickCount != 2 || e.LeftButton != MouseButtonState.Pressed || element == null)
                return;

            ICommand command = GetLeftDoubleClickCommand(element);
            object param = GetLeftDoubleClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        private static void Control_RightDoubleClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (e.ClickCount != 2 || e.RightButton != MouseButtonState.Pressed || element == null)
                return;

            ICommand command = GetRightDoubleClickCommand(element);
            object param = GetRightDoubleClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        
        public static readonly DependencyProperty LeftClickCommandProperty =
          DependencyProperty.RegisterAttached("LeftClickCommand", typeof(ICommand),
          typeof(ExtendedCommands), new PropertyMetadata(default(ICommand),
          OnLeftClickCommandChanged));

        public static ICommand GetLeftClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(LeftClickCommandProperty);
        }

        public static void SetLeftClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(LeftClickCommandProperty, value);
        }

        private static void OnLeftClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element != null)
            {
                if (e.OldValue == null && e.NewValue != null)
                    element.MouseDown += new MouseButtonEventHandler(Control_LeftClickMouseDown);
                else if (e.OldValue != null && e.NewValue == null)
                    element.MouseDown -= new MouseButtonEventHandler(Control_LeftClickMouseDown);
            }
        }

        
        public static readonly DependencyProperty LeftClickCommandParameterProperty =
          DependencyProperty.RegisterAttached("LeftClickCommandParameter", typeof(object),
          typeof(ExtendedCommands), new PropertyMetadata(default(object)));

        public static object GetLeftClickCommandParameter(FrameworkElement element)
        {
            return (object)element.GetValue(LeftClickCommandParameterProperty);
        }

        public static void SetLeftClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(LeftClickCommandParameterProperty, value);
        }

        
        public static readonly DependencyProperty LeftDoubleClickCommandProperty =
          DependencyProperty.RegisterAttached("LeftDoubleClickCommand", typeof(ICommand),
          typeof(ExtendedCommands), new PropertyMetadata(default(ICommand)));

        public static ICommand GetLeftDoubleClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(LeftDoubleClickCommandProperty);
        }

        public static void SetLeftDoubleClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(LeftDoubleClickCommandProperty, value);
        }

        private static void OnLeftDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element != null)
            {
                if (e.OldValue == null && e.NewValue != null)
                    element.MouseDown += new MouseButtonEventHandler(Control_LeftDoubleClickMouseDown);
                else if (e.OldValue != null && e.NewValue == null)
                    element.MouseDown -= new MouseButtonEventHandler(Control_LeftDoubleClickMouseDown);
            }
        }
                     
        
                   public static readonly DependencyProperty LeftDoubleClickCommandParameterProperty = 
                     DependencyProperty.RegisterAttached("LeftDoubleClickCommandParameter", typeof(object), 
                     typeof(ExtendedCommands), new PropertyMetadata(default(object))
                     );
                  
                   public static object GetLeftDoubleClickCommandParameter(FrameworkElement element)
                   {
                      return (object)element.GetValue(LeftDoubleClickCommandParameterProperty);
                   }

                   public static void SetLeftDoubleClickCommandParameter(FrameworkElement element, object value)
                   {
                      element.SetValue(LeftDoubleClickCommandParameterProperty, value);
                   }
 
                   private static void OnLeftDoubleClickCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
                    {
                      FrameworkElement me = d as FrameworkElement;
                    }
                
        public static readonly DependencyProperty RightClickCommandProperty =
          DependencyProperty.RegisterAttached("RightClickCommand", typeof(ICommand),
          typeof(ExtendedCommands), new PropertyMetadata(default(ICommand),
          OnRightClickCommandChanged));

        public static ICommand GetRightClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(RightClickCommandProperty);
        }

        public static void SetRightClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(RightClickCommandProperty, value);
        }

        private static void OnRightClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element != null)
            {
                if (e.OldValue == null && e.NewValue != null)
                    element.MouseDown += new MouseButtonEventHandler(Control_RightClickMouseDown);
                else if (e.OldValue != null && e.NewValue == null)
                    element.MouseDown -= new MouseButtonEventHandler(Control_RightClickMouseDown);
            }
        }

        
        public static readonly DependencyProperty RightClickCommandParameterProperty =
          DependencyProperty.RegisterAttached("RightClickCommandParameter", typeof(object),
          typeof(ExtendedCommands), new PropertyMetadata(default(object)));

        public static object GetRightClickCommandParameter(FrameworkElement element)
        {
            return (object)element.GetValue(RightClickCommandParameterProperty);
        }

        public static void SetRightClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(RightClickCommandParameterProperty, value);
        }
        
        public static readonly DependencyProperty RightDoubleClickCommandProperty =
          DependencyProperty.RegisterAttached("RightDoubleClickCommand", typeof(ICommand),
          typeof(ExtendedCommands), new PropertyMetadata(default(ICommand),
          OnRightDoubleClickCommandChanged));

        public static ICommand GetRightDoubleClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(RightDoubleClickCommandProperty);
        }

        public static void SetRightDoubleClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(RightDoubleClickCommandProperty, value);
        }

        private static void OnRightDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element != null)
            {
                if (e.OldValue == null && e.NewValue != null)
                    element.MouseDown += new MouseButtonEventHandler(Control_RightDoubleClickMouseDown);
                else if (e.OldValue != null && e.NewValue == null)
                    element.MouseDown -= new MouseButtonEventHandler(Control_RightDoubleClickMouseDown);
            }
        }

        
        public static readonly DependencyProperty RightDoubleClickCommandParameterProperty =
          DependencyProperty.RegisterAttached("RightDoubleClickCommandParameter", typeof(object),
          typeof(ExtendedCommands), new PropertyMetadata(default(object)));

        public static object GetRightDoubleClickCommandParameter(FrameworkElement element)
        {
            return (object)element.GetValue(RightDoubleClickCommandParameterProperty);
        }

        public static void SetRightDoubleClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(RightDoubleClickCommandParameterProperty, value);
        }
                
    }
}