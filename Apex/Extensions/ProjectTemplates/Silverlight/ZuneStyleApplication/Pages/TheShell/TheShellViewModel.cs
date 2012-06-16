using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;
using ZuneStyleApplication.ViewModels;

namespace ZuneStyleApplication.Pages.TheShell
{
    /// <summary>
    /// The TheShellViewModel ViewModel class.
    /// </summary>
    public class TheShellViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheShellViewModel"/> class.
        /// </summary>
        public TheShellViewModel()
        {
            Title = "The Shell";

            //  Create the show popup command. It actually won't do anything in the 
            //  view model, but a view can still handle it.
            ShowPopupCommand = new Command(() => { });
        }

        /// <summary>
        /// Gets the show popup command.
        /// </summary>
        public Command ShowPopupCommand { get; private set; }
    }
}
