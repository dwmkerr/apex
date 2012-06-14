using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using WpfDialogApplication.Models;
using Apex;

namespace WpfDialogApplication.ViewModels
{
    /// <summary>
    /// The main viewmodel class.
    /// </summary>
    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            //  Wire up commands.
            CloseCommand = new Command(DoCloseCommand);

            //  Get the last run time from the model - as long as we're not in the designer.
            if (Apex.Design.DesignTime.IsDesignTime)
                Title += " (Design Time)";
            else
                LastRunTime = ApexBroker.GetModel<IAppModel>().LoadLastRunTime();
        }
        
        /// <summary>
        /// The NotifyingProperty for the Title property.
        /// </summary>
        private readonly NotifyingProperty TitleProperty =
          new NotifyingProperty("Title", typeof(string), "My Application");

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        /// <value>The value of Title.</value>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        
        /// <summary>
        /// The NotifyingProperty for the LastRunTime property.
        /// </summary>
        private readonly NotifyingProperty LastRunTimeProperty =
          new NotifyingProperty("LastRunTime", typeof(DateTime), default(DateTime));

        /// <summary>
        /// Gets or sets LastRunTime.
        /// </summary>
        /// <value>The value of LastRunTime.</value>
        public DateTime LastRunTime
        {
            get { return (DateTime)GetValue(LastRunTimeProperty); }
            set { SetValue(LastRunTimeProperty, value); }
        }

        /// <summary>
        /// Performs the Close command.
        /// </summary>
        /// <param name="parameter">The Close command parameter.</param>
        private void DoCloseCommand(object parameter)
        {
        }

        /// <summary>
        /// Gets the Close command.
        /// </summary>
        /// <value>The value of .</value>
        public Command CloseCommand
        {
            get;
            private set;
        } 
    }
}
