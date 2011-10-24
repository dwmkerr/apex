using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using System.Collections.ObjectModel;

namespace CommandingExample
{
  public class MainViewModel : ViewModel
  {
    public MainViewModel()
    {
      //  Create the simple command - calls DoSimpleCommand.
      simpleCommand = new Command(DoSimpleCommand, true);

      //  Create the lambda command, no extra function necessary.
      lambaCommand = new Command(
        () =>
        {
          Messages.Add("Calling the Lamba Command - no explicit function necessary.");
        }
        , true);

      //  Create the cancellable command.
      cancellableCommand = new Command(
        () =>
        {
          Messages.Add("Successfully called the cancellable command.");
        }
        , true);
    }

    private void DoSimpleCommand()
    {
      //  Add a message.
      Messages.Add("Calling 'DoSimpleCommand'.");
    }

    private Command simpleCommand;

    public Command SimpleCommand
    {
      get { return simpleCommand; }
    }

    private Command lambaCommand;

    public Command LambaCommand
    {
      get { return lambaCommand; }
    }

    private Command cancellableCommand;

    public Command CancellableCommand
    {
      get { return cancellableCommand; }
    }

    private ObservableCollection<string> messages = new ObservableCollection<string>();

    public ObservableCollection<string> Messages
    {
      get { return messages; }
    }
  }
}
