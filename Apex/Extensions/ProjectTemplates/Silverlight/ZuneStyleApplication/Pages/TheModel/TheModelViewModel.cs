using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex;
using Apex.MVVM;
using ZuneStyleApplication.Models;
using ZuneStyleApplication.ViewModels;

namespace ZuneStyleApplication.Pages.TheModel
{
    /// <summary>
    /// The TheModelViewModel ViewModel class.
    /// </summary>
    public class TheModelViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheModelViewModel"/> class.
        /// </summary>
        public TheModelViewModel()
        {
            Title = "The Model";

            //  Get the Zune Model.
            var zuneModel = ApexBroker.GetModel<IZuneModel>();

            //  Get the albums.
            var albums = zuneModel.GetAlbums();
        }
    }
}
