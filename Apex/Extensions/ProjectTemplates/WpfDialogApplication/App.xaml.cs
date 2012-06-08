using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Apex.MVVM;
using WpfDialogApplication.Models;

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
            base.OnStartup(e);

            //  Create the main model for the application.
            var appModel = new AppModel();

            //  Register the model with the broker.
            ApexBroker.RegisterModel<IAppModel>(appModel);
        }
    }
}
