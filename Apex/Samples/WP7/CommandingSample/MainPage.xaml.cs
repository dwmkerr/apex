using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace CommandingSample
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

      ViewModel.EventsCommand.Executing += new Apex.MVVM.CancelCommandEventHandler(EventsCommand_Executing);
      ViewModel.EventsCommand.Executed += new Apex.MVVM.CommandEventHandler(EventsCommand_Executed);

      ViewModel.CancellableAsyncCommand.Executing += new Apex.MVVM.CancelCommandEventHandler(CancellableAsyncCommand_Executing);
      ViewModel.CancellableAsyncCommand.Executed += new Apex.MVVM.CommandEventHandler(CancellableAsyncCommand_Executed);
      ViewModel.CancellableAsyncCommand.Cancelled += new Apex.MVVM.CommandEventHandler(CancellableAsyncCommand_Cancelled);
    }

    void CancellableAsyncCommand_Cancelled(object sender, Apex.MVVM.CommandEventArgs args)
    {
      ViewModel.Messages.Add("View: Cancellable Async Command Cancelled.");
    }

    void CancellableAsyncCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
    {
      ViewModel.Messages.Add("View: Cancellable Async Command Executed.");
    }

    void CancellableAsyncCommand_Executing(object sender, Apex.MVVM.CancelCommandEventArgs args)
    {
      ViewModel.Messages.Add("View: Cancellable Async Command Executing.");
    }

    public MainViewModel ViewModel
    {
      get { return (MainViewModel)DataContext; }
    }

    void EventsCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
    {
      ViewModel.Messages.Add("The command has finished - this is the View speaking!");
    }

    void EventsCommand_Executing(object sender, Apex.MVVM.CancelCommandEventArgs args)
    {
      if (MessageBox.Show("Continue with the command?", "Continue?", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
        args.Cancel = true;
    }
  }
}