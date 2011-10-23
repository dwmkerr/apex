using System.Windows.Input;
using System;
using System.Windows.Threading;
namespace Apex.MVVM
{
    public class AsynchronousCommand : ViewModelCommand
    {
        public AsynchronousCommand(Action action, bool canExecute) : base(action, canExecute) {}

        public AsynchronousCommand(Action<object> parameterizedAction, bool canExecute) : base(parameterizedAction, canExecute) {}

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="param">The param.</param>
        public override void DoExecute(object param)
        {
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
                    del.EndInvoke(asyncResult);

                    callingDispatcher.BeginInvoke(
                        ((Action)(() =>
                            {
                                InvokeExecuted(new CommandEventArgs() { Parameter = param });
                            })));

                    IsExecuting = false;
                }
            , null);
        }

        public void ReportProgress(Action action)
        {
            if (IsExecuting)
                callingDispatcher.BeginInvoke(((Action)(() => { action(); })));
        }

        protected Dispatcher callingDispatcher;

        public bool IsExecuting
        {
            get;
            set;
        }
    }
}