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
    public static readonly DependencyProperty ClickCommandProperty = DependencyProperty.RegisterAttached("ClickCommand",
      typeof(ICommand), typeof(ExtendedCommands), new UIPropertyMetadata(null, OnClickCommandPropertyChanged));

    public static readonly DependencyProperty ClickCommandParameterProperty = DependencyProperty.RegisterAttached("ClickCommandParameter",
      typeof(object), typeof(ExtendedCommands), new UIPropertyMetadata(null));

    public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.RegisterAttached("DoubleClickCommand", 
      typeof(ICommand), typeof(ExtendedCommands), new UIPropertyMetadata(null, OnDoubleClickCommandPropertyChanged));

    public static readonly DependencyProperty DoubleClickCommandParameterProperty = DependencyProperty.RegisterAttached("DoubleClickCommandParameter", 
      typeof(object), typeof(ExtendedCommands), new UIPropertyMetadata(null));

    public static readonly DependencyProperty contextMenuDataContextProperty =
        DependencyProperty.RegisterAttached("ContextMenuDataContext",
        typeof(object), typeof(ExtendedCommands),
        new UIPropertyMetadata(ContextMenuDataContextChanged));

    public static object GetContextMenuDataContext(FrameworkElement obj)
    {
      return obj.GetValue(contextMenuDataContextProperty);
    }

    public static void SetContextMenuDataContext(FrameworkElement obj, object value)
    {
      obj.SetValue(contextMenuDataContextProperty, value);
    }

    private static void ContextMenuDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      FrameworkElement frameworkElement = d as FrameworkElement;
      if (frameworkElement == null)
        return;

      if (frameworkElement.ContextMenu != null)
        frameworkElement.ContextMenu.DataContext = GetContextMenuDataContext(frameworkElement);
    }


    public static ICommand GetClickCommand(DependencyObject obj)
    {
      return (ICommand)obj.GetValue(ClickCommandProperty);
    }

    public static void SetClickCommand(DependencyObject obj, ICommand value)
    {
      obj.SetValue(ClickCommandProperty, value);
    }

    public static object GetClickCommandParameter(DependencyObject obj)
    {
      return (object)obj.GetValue(ClickCommandParameterProperty);
    }

    public static void SetClickCommandParameter(DependencyObject obj, object value)
    {
      obj.SetValue(ClickCommandParameterProperty, value);
    }

    public static ICommand GetDoubleClickCommand(DependencyObject obj)
    {
      return (ICommand)obj.GetValue(DoubleClickCommandProperty);
    }

    public static void SetDoubleClickCommand(DependencyObject obj, ICommand value)
    {
      obj.SetValue(DoubleClickCommandProperty, value);
    }

    public static object GetDoubleClickCommandParameter(DependencyObject obj)
    {
      return (object)obj.GetValue(DoubleClickCommandParameterProperty);
    }

    public static void SetDoubleClickCommandParameter(DependencyObject obj, object value)
    {
      obj.SetValue(DoubleClickCommandParameterProperty, value);
    }

    private static void OnClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var element = d as UIElement;
      if (element != null)
      {
        if (e.OldValue == null && e.NewValue != null)
        {
          element.MouseDown += new MouseButtonEventHandler(Control_ClickMouseDown);
        }
        else if (e.OldValue != null && e.NewValue == null)
        {
          element.MouseDown -= new MouseButtonEventHandler(Control_ClickMouseDown);
        }
      }
    }

    private static void OnDoubleClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var element = d as UIElement;
      if (element != null)
      {
        if (e.OldValue == null && e.NewValue != null)
        {
          element.MouseDown += new MouseButtonEventHandler(Control_DoubleClickMouseDown);
        }
        else if (e.OldValue != null && e.NewValue == null)
        {
          element.MouseDown -= new MouseButtonEventHandler(Control_DoubleClickMouseDown);
        }
      }
    }

    private static void Control_ClickMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount == 1)
      {
        var element = sender as UIElement;
        if (element != null)
        {
          var command = GetClickCommand(element);
          var parameter = GetClickCommandParameter(element);
          if (command != null && command.CanExecute(parameter))
          {
            e.Handled = true;
            command.Execute(parameter);
          }
        }
      }
    }

    private static void Control_DoubleClickMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount == 2)
      {
        var element = sender as UIElement;
        if (element != null)
        {
          var command = GetDoubleClickCommand(element);
          var parameter = GetDoubleClickCommandParameter(element);
          if (command != null && command.CanExecute(parameter))
          {
            e.Handled = true;
            command.Execute(parameter);
          }
        }
      }
    }
  }
}
