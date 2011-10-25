using System.Windows.Input;
using System;
using System.Windows.Threading;
using System.ComponentModel;
namespace Apex.MVVM
{
    public class AsynchronousCommand : Command, INotifyPropertyChanged
    {
        public AsynchronousCommand(Action action, bool canExecute) : base(action, canExecute) {}

        public AsynchronousCommand(Action<object> parameterizedAction, bool canExecute) : base(parameterizedAction, canExecute) {}

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
            CancelCommandEventArgs args = new CancelCommandEventArgs() { Parameter = param, Cancel = false };
            InvokeExecuting(args);

            //  If the event has been cancelled, bail now.
            if (args.Cancel)
                return;

            //  We are executing.
            IsExecuting = true;

            //  Store the calling dispatcher.
            callingDispatcher = Dispatcher.CurrentDispatcher;

            //  Call the action or the parameterized action, whichever has been set.
            //  However, invoke this on a new thread.
            Action<object> del = InvokeAction;
            del.BeginInvoke(param,
                (asyncResult) =>
                {
                  //  End the asynchronous call.
                    del.EndInvoke(asyncResult);

                  //  Invoke the executed event on the calling thread.
                    callingDispatcher.BeginInvoke(
                        ((Action)(() =>
                            {
                                InvokeExecuted(new CommandEventArgs() { Parameter = param });
                            })));

                  //  We are no longer executing.
                    IsExecuting = false;
                }
            , null);
        }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName)
        {
          //  Store the event handler - in case it changes between
          //  the line to check it and the line to fire it.
          PropertyChangedEventHandler propertyChanged = PropertyChanged;

          //  If the event has been subscribed to, fire it.
          if (propertyChanged != null)
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Reports progress on the thread which invoked the command.
        /// </summary>
        /// <param name="action">The action.</param>
        public void ReportProgress(Action action)
        {
            if (IsExecuting)
                callingDispatcher.BeginInvoke(((Action)(() => { action(); })));
        }

        protected Dispatcher callingDispatcher;

      /// <summary>
      /// Flag indicating that the command is executing.
      /// </summary>
      private bool isExecuting = false;

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is executing.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is executing; otherwise, <c>false</c>.
        /// </value>
        public bool IsExecuting
        {
          get 
          { 
            return isExecuting; 
          }
          set
          {
            if (isExecuting != value)
            {
              isExecuting = value;
              NotifyPropertyChanged("IsExecuting");
            }
          }
        }
      
    }
}