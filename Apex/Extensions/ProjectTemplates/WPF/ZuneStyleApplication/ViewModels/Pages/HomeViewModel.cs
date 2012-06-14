using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ZuneStyleApplication.ViewModels
{
    /// <summary>
    /// The HomeViewModel ViewModel class.
    /// </summary>
    public class HomeViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        public HomeViewModel()
        {
            Title = "Home";
        }
    }
}
