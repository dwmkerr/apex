using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Gallery.MVVM.CommandingSample
{
    /// <summary>
    /// The CommandingSampleViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class CommandingSampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandingSampleViewModel"/> class.
        /// </summary>
        public CommandingSampleViewModel()
        {
            Title = "Commanding Sample";

            //  Create the simple command - calls DoSimpleCommand.
            SimpleCommand = new Command(DoSimpleCommand);

            //  Create the lambda command, no extra function necessary.
            LambdaCommand = new Command(
              () =>
              {
                  Messages.Add("Calling the Lamba Command - no explicit function necessary.");
              });

            //  Create the parameterized command.
            ParameterisedCommand = new Command(DoParameterisedCommand, true);

            //  Create the enable/disable command, initially disabled.
            EnableDisableCommand = new Command(
                () =>
                {
                    Messages.Add("Enable/Disable command called.");
                }, false);

            //  Create the events command.
            EventsCommand = new Command(
                () =>
                {
                    Messages.Add("Calling the Events Command.");
                });

            //  Create the async command.
            AsyncCommand1 = new AsynchronousCommand(
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Report progress.
                        AsyncCommand1.ReportProgress(() => { Messages.Add(i.ToString()); });

                        System.Threading.Thread.Sleep(200);
                    }
                });

            //  Create the async command.
            AsyncCommand2 = new AsynchronousCommand(
                () =>
                {
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        //  Report progress.
                        AsyncCommand2.ReportProgress(() => { Messages.Add(c.ToString()); });

                        System.Threading.Thread.Sleep(100);
                    }
                });

            //  Create the cancellable async command.
            CancellableAsyncCommand = new AsynchronousCommand(
              () =>
              {
                  for (int i = 1; i <= 100; i++)
                  {
                      //  Do we need to cancel?
                      if (CancellableAsyncCommand.CancelIfRequested())
                          return;

                      //  Report progress.
                      CancellableAsyncCommand.ReportProgress(() => { Messages.Add(i.ToString()); });

                      System.Threading.Thread.Sleep(100);
                  }
              });

            //  Create the disable during execution command.
            DisabledDuringExecutionAsyncCommand = new AsynchronousCommand(
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Report progress.
                        DisabledDuringExecutionAsyncCommand.ReportProgress(() => { Messages.Add(i.ToString()); });

                        System.Threading.Thread.Sleep(200);
                    }
                });
            DisabledDuringExecutionAsyncCommand.DisableDuringExecution = true;

            //  Create the event binding command.
            EventBindingCommand = new Command(DoEventBindingCommand);

            //  Create the typed commands.
            IntTypedCommand = new Command<int>(DoIntTypedCommand);
            StringTypedCommand = new Command<string>(DoStringTypedCommand);
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

        /// <summary>
        /// Does the int typed command.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void DoIntTypedCommand(int parameter)
        {
            Messages.Add("Received an int parameter: " + parameter);
        }

        /// <summary>
        /// Does the string typed command.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void DoStringTypedCommand(string parameter)
        {
            Messages.Add("Received a string parameter: " + parameter);
        }
        
        public Command SimpleCommand
        {
            get;
            private set;
        }

        public Command LambdaCommand
        {
            get;
            private set;
        }

        public Command ParameterisedCommand
        {
            get;
            private set;
        }

        public Command EnableDisableCommand
        {
            get;
            private set;
        }

        public Command EventsCommand
        {
            get;
            private set;
        }

        public AsynchronousCommand AsyncCommand1
        {
            get;
            private set;
        }

        public AsynchronousCommand AsyncCommand2
        {
            get;
            private set;
        }

        public AsynchronousCommand CancellableAsyncCommand
        {
            get;
            private set;
        }

        public AsynchronousCommand DisabledDuringExecutionAsyncCommand { get; private set; }

        public Command EventBindingCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the int typed command.
        /// </summary>
        public Command<int> IntTypedCommand { get; private set; }

        /// <summary>
        /// Gets the string typed command.
        /// </summary>
        public Command<string> StringTypedCommand { get; private set; }

        /// <summary>
        /// The messages observable collection.
        /// </summary>
        private readonly ObservableCollection<string> messages = new ObservableCollection<string>();

        /// <summary>
        /// Gets the messages.
        /// </summary>
        public ObservableCollection<string> Messages
        {
            get { return messages; }
        }
    }
}
