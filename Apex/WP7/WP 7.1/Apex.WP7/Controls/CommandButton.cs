using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Apex.Controls
{
  public class CommandButton : Button
  {

      //    The button command is supported out-of-the box in WP7.1
#if !WP71

    public CommandButton()
    {
      Click += new RoutedEventHandler(CommandButton_Click);
    }

    void CommandButton_Click(object sender, RoutedEventArgs e)
    {
      if (Command != null)
      {
        Command.Execute(CommandParameter);
      }
    }
    
    private static readonly DependencyProperty CommandProperty =
      DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandButton),
      new PropertyMetadata(null, new PropertyChangedCallback(OnCommandChanged)));

    
    private static readonly DependencyProperty CommandParameterProperty =
      DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandButton),
      new PropertyMetadata(null, new PropertyChangedCallback(OnCommandParameterChanged)));

    public object CommandParameter
    {
      get { return (object)GetValue(CommandParameterProperty); }
      set { SetValue(CommandParameterProperty, value); }
    }

    private static void OnCommandParameterChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
    {
      CommandButton me = o as CommandButton;
    }
                

    public ICommand Command
    {
      get { return (ICommand)GetValue(CommandProperty); }
      set { SetValue(CommandProperty, value); }
    }

    private static void OnCommandChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
    {
      CommandButton me = o as CommandButton;

      ICommand oldCommand = (ICommand)args.OldValue;
      ICommand newCommand = (ICommand)args.NewValue;

      me.RewireCommand(oldCommand, newCommand);

      if (newCommand != null)
        me.IsEnabled = newCommand.CanExecute(me.CommandParameter);
    }

    private void RewireCommand(ICommand oldCommand, ICommand newCommand)
    {
      if (oldCommand != null)
      {
        newCommand.CanExecuteChanged -= new EventHandler(newCommand_CanExecuteChanged);
      }
      if (newCommand != null)
      {
        newCommand.CanExecuteChanged += new EventHandler(newCommand_CanExecuteChanged);
      }
    }

    void newCommand_CanExecuteChanged(object sender, EventArgs e)
    {
      IsEnabled = Command.CanExecute(CommandParameter);
    }      
#endif
  }

}
