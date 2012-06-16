using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace WpfDialogApplication.Models
{
    /// <summary>
    /// The main application model class.
    /// By decorating the class with the 'Model' attribute, we will always
    /// get this class back when we request a model via 'ApexBroker.GetModel'.
    /// </summary>
    [Model]
    public class AppModel : IAppModel
    {
        /// <summary>
        /// Gets the last run time (i.e. the time the application was last run).
        /// </summary>
        /// <returns>
        /// The last run time.
        /// </returns>
        public DateTime LoadLastRunTime()
        {
            //  Return the last run time from the settings.
            var lastDateTime = Properties.Settings.Default.LastRunTime;
            if (lastDateTime == null || lastDateTime == DateTime.MinValue)
                lastDateTime = DateTime.Now;
            return lastDateTime;
        }

        /// <summary>
        /// Saves the last run time.
        /// </summary>
        /// <param name="lastRunTime">The last run time.</param>
        public void SaveLastRunTime(DateTime lastRunTime)
        {
            //  Save the last run time in the settings.
            Properties.Settings.Default.LastRunTime = lastRunTime;
            Properties.Settings.Default.Save();
        }
    }
}
