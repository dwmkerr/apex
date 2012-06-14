using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ZuneStyleApplication.ViewModels
{
    /// <summary>
    /// The MusicViewModel ViewModel class.
    /// </summary>
    public class MusicViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicViewModel"/> class.
        /// </summary>
        public MusicViewModel()
        {
            Title = "Music";
        }
    }
}
