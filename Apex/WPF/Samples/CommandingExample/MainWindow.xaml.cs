using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            viewModel.EventsCommand.Executing += new Apex.MVVM.CancelCommandEventHandler(EventsCommand_Executing);
            viewModel.EventsCommand.Executed += new Apex.MVVM.CommandEventHandler(EventsCommand_Executed);
        }

        void EventsCommand_Executed(object sender, Apex.MVVM.CommandEventArgs args)
        {
            viewModel.Messages.Add("The command has finished - this is the View speaking!");
        }

        void EventsCommand_Executing(object sender, Apex.MVVM.CancelCommandEventArgs args)
        {
            if (MessageBox.Show("Cancel the command?", "Cancel?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                args.Cancel = true;
        }
    }
}
