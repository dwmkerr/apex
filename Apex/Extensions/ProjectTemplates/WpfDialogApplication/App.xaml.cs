using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Apex.MVVM;
using WpfDialogApplication.Models;
using Apex;

namespace WpfDialogApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //  Call the base.
            base.OnStartup(e);

            //  Initialise the broker.
            //ApexBroker.Initialise();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //  Save the last run time.
            ApexBroker.GetModel<IAppModel>().SaveLastRunTime(DateTime.Now);

            base.OnExit(e);
        }
    }
}
