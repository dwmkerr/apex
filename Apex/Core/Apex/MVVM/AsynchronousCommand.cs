using System;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading;

namespace Apex.MVVM
{
    /// <summary>
    /// The AsynchronousCommand is a Command that runs on a thread from the thread pool.
    /// </summary>
    public class AsynchronousCommand : Command, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsynchronousCommand"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="canExecute">if set to <c>true</c> the command can execute.</param>
        public AsynchronousCommand(Action action, bool canExecute = true)
            : base(action, canExecute)
        {
            //  Initialise the command.
            Initialise();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsynchronousCommand"/> class.
        /// </summary>
        /// <param name="parameterizedAction">The parameterized action.</param>
        /// <param name="canExecute">if set to <c>true</c> [can execute].</param>
        public AsynchronousCommand(Action<object> parameterizedAction, bool canExecute = true)
            : base(parameterizedAction, canExecute)
        {

            //  Initialise the command.
            Initialise();
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        private void Initialise()
        {
            //  Construct the cancel command.
            CancelCommand = new Command(
                () =>
                    {
                        //  Set the Is Cancellation Requested flag.
                        IsCancellationRequested = true;
                    });
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="param">The param.</param>
        public override void DoExecute(object param)
        {
            //  If we are already executing, do not continue.
            if (IsExecuting)
                return;

            //  Invoke the executing command, allowing the command to be cancelled.
            var args = new CancelCommandEventArgs {Parameter = param, Cancel = false};
            InvokeExecuting(args);

            //  If the event has been cancelled, bail now.
            if (args.Cancel)
                return;

            //  We are executing.
            IsExecuting = true;

            //  If we disable during execution, disable now.
            if (DisableDuringExecution)
                CanExecute = false;

            //  Store the calling dispatcher. Use the Consistency object
            //  so that the same call works properly in WPF/SL/WP7.
            callingDispatcher = Consistency.DispatcherHelper.CurrentDispatcher;

            // Run the action on a new thread from the thread pool (this will therefore work in SL and WP7 as well).
            ThreadPool.QueueUserWorkItem(
                state =>
                    {
                        //  Invoke the action.
                        InvokeAction(param);

                        //  Fire the executed event and set the executing state.
                        ReportProgress(
                            () =>
                                {
                                    //  We are no longer executing.
                                    IsExecuting = false;

                                    //  If we were cancelled, invoke the cancelled event - otherwise invoke executed.
                                    if (IsCancellationRequested)
                                        InvokeCancelled(new CommandEventArgs {Parameter = param});
                                    else
                                        InvokeExecuted(new CommandEventArgs {Parameter = param});

                                    //  We are no longer requesting cancellation.
                                    IsCancellationRequested = false;

                                    //  If we disable during execution, re-enable now.
                                    if (DisableDuringExecution)
                                        CanExecute = true;
                                }
                            );
                    }
                );
        }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            //  Store the event handler - in case it changes between
            //  the line to check it and the line to fire it.
            var propertyChanged = PropertyChanged;

            //  If the event has been subscribed to, fire it.
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Reports progress on the thread which invoked the command.
        /// </summary>
        /// <param name="progressAction">The progress action.</param>
        public void ReportProgress(Action progressAction)
        {
            //  If we're not executing, no need to report anything.
            if (!IsExecuting) 
                return;

            if (callingDispatcher.CheckAccess())
                progressAction();
            else
                callingDispatcher.BeginInvoke(progressAction);
        }

        /// <summary>
        /// Cancels the command if requested.
        /// </summary>
        /// <returns>True if the command has been cancelled and we must return.</returns>
        public bool CancelIfRequested()
        {
            //  If we haven't requested cancellation, there's nothing to do.
            if (IsCancellationRequested == false)
                return false;

            //  We're done.
            return true;
        }

        /// <summary>
        /// Invokes the cancelled event.
        /// </summary>
        /// <param name="args">The <see cref="Apex.MVVM.CommandEventArgs"/> instance containing the event data.</param>
        protected void InvokeCancelled(CommandEventArgs args)
        {
            //  Get the event.
            var cancelled = Cancelled;

            //  Call the cancelled event.
            if (cancelled != null)
                cancelled(this, args);
        }

        /// <summary>
        /// The calling dispatcher.
        /// </summary>
        protected Dispatcher callingDispatcher;

        /// <summary>
        /// Flag indicating that the command is executing.
        /// </summary>
        private bool isExecuting;

        /// <summary>
        /// Flag indicated that cancellation has been requested.
        /// </summary>
        private bool isCancellationRequested;

        /// <summary>
        /// Flag indicating that a command must be disabled during its execution.
        /// </summary>
        private bool disableDuringExecuting;

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when the command is cancelled.
        /// </summary>
        public event CommandEventHandler Cancelled;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is executing.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is executing; otherwise, <c>false</c>.
        /// </value>
        public bool IsExecuting
        {
            get { return isExecuting; }
            set
            {
                if (isExecuting != value)
                {
                    isExecuting = value;
                    NotifyPropertyChanged("IsExecuting");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is cancellation requested.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is cancellation requested; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancellationRequested
        {
            get { return isCancellationRequested; }
            set
            {
                if (isCancellationRequested != value)
                {
                    isCancellationRequested = value;
                    NotifyPropertyChanged("IsCancellationRequested");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to disable the command during execution.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the command should be disabled during execution; otherwise, <c>false</c>.
        /// </value>
        public bool DisableDuringExecution
        {
            get { return disableDuringExecuting; }
            set
            {
                if (disableDuringExecuting != value)
                {
                    disableDuringExecuting = value;
                    NotifyPropertyChanged("DisableDuringExecution");
                }
            }
        }

        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        public Command CancelCommand { get; private set; }
    }
}