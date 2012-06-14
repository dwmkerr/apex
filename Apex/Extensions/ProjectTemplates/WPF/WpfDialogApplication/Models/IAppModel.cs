using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfDialogApplication.Models
{
    /// <summary>
    /// The base interface for the Application Model.
    /// </summary>
    public interface IAppModel
    {
        /// <summary>
        /// Gets the last run time (i.e. the time the application was last run).
        /// </summary>
        /// <returns>The last run time.</returns>
        DateTime LoadLastRunTime();

        /// <summary>
        /// Saves the last run time.
        /// </summary>
        /// <param name="lastRunTime">The last run time.</param>
        void SaveLastRunTime(DateTime lastRunTime);
    }
}
