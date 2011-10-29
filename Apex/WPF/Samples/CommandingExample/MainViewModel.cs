using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using System.Collections.ObjectModel;

namespace CommandingSample
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            //  Create the simple command - calls DoSimpleCommand.
            simpleCommand = new Command(DoSimpleCommand);

            //  Create the lambda command, no extra function necessary.
            lambdaCommand = new Command(
              () =>
              {
                  Messages.Add("Calling the Lamba Command - no explicit function necessary.");
              });

            //  Create the parameterized command.
            parameterizedCommand = new Command(DoParameterisedCommand, true);

            //  Create the enable/disable command, initially disabled.
            enableDisableCommand = new Command(
                () =>
                {
                    Messages.Add("Enable/Disable command called.");
                }, false);

            //  Create the events command.
            eventsCommand = new Command(
                () =>
                {
                    Messages.Add("Calling the Events Command.");
                });

            //  Create the async command.
            asyncCommand1 = new AsynchronousCommand(
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Report progress.
                        asyncCommand1.ReportProgress(() => { Messages.Add(i.ToString()); });

                        System.Threading.Thread.Sleep(200);
                    }
                });

            //  Create the async command.
            asyncCommand2 = new AsynchronousCommand(
                () =>
                {
                  for (char c = 'A'; c <= 'Z'; c++)
                  {
                    //  Report progress.
                    asyncCommand2.ReportProgress(() => { Messages.Add(c.ToString()); });

                    System.Threading.Thread.Sleep(100);
                  }
                });

          //  Create the cancellable async command.
          cancellableAsyncCommand = new AsynchronousCommand(
            () => 
              {
                for(int i = 1; i <= 100; i++)
                {
                  //  Do we need to cancel?
                  if(cancellableAsyncCommand.CancelIfRequested())
                    return;

                  //  Report progress.
                  cancellableAsyncCommand.ReportProgress( () => { Messages.Add(i.ToString()); } );

                  System.Threading.Thread.Sleep(100);
                }
              });

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

        private AsynchronousCommand asyncCommand1;

        public AsynchronousCommand AsyncCommand1
        {
            get { return asyncCommand1; }
        }

        private AsynchronousCommand asyncCommand2;

        public AsynchronousCommand AsyncCommand2
        {
          get { return asyncCommand2; }
        }

        private AsynchronousCommand cancellableAsyncCommand;

        public AsynchronousCommand CancellableAsyncCommand
        {
          get { return cancellableAsyncCommand; }
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