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
            lambdaCommand = new Command(
              () =>
              {
                  Messages.Add("Calling the Lamba Command - no explicit function necessary.");
              }
              , true);

            //  Create the parameterized command.
            parameterizedCommand = new Command(DoParameterisedCommand, true);

            //  Create the enable/disable command.
            enableDisableCommand = new Command(
                () =>
                {
                    Messages.Add("Enable/Disable command called.");
                }
            , true);

            //  Create the events command.
            eventsCommand = new Command(
                () =>
                {
                    Messages.Add("Calling the Events Command.");
                }
            , true);

            //  Create the async command.
            asyncCommand = new AsynchronousCommand(
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Report progress.
                        asyncCommand.ReportProgress(() => { Messages.Add(i.ToString()); });

                        System.Threading.Thread.Sleep(200);
                    }
                }
            , true);

            //  Create the event binding command.
            eventBindingCommand = new Command(DoEventBindingCommand, true);
        }

        private void DoSimpleCommand()
        {
            //  Add a message.
            Messages.Add("Calling 'DoSimpleCommand'.");
        }

        private void DoParameterisedCommand(object parameter)
        {
            Messages.Add("Calling a Parameterised Command - the Parameter is '" + parameter.ToString() + "'.");
        }

        private void DoEventBindingCommand()
        {
            Messages.Add("Called a command via an event.");
        }

        private Command simpleCommand;

        public Command SimpleCommand
        {
            get { return simpleCommand; }
        }

        private Command lambdaCommand;

        public Command LambdaCommand
        {
            get { return lambdaCommand; }
        }

        private Command parameterizedCommand;

        public Command ParameterisedCommand
        {
            get { return parameterizedCommand; }
        }

        private Command enableDisableCommand;

        public Command EnableDisableCommand
        {
            get { return enableDisableCommand; }
        }

        private Command eventsCommand;

        public Command EventsCommand
        {
            get { return eventsCommand; }
        }

        private AsynchronousCommand asyncCommand;

        public AsynchronousCommand AsyncCommand
        {
            get { return asyncCommand; }
        }

        private Command eventBindingCommand;

        public Command EventBindingCommand
        {
            get { return eventBindingCommand; }
        }

        private ObservableCollection<string> messages = new ObservableCollection<string>();

        public ObservableCollection<string> Messages
        {
            get { return messages; }
        }
    }
}