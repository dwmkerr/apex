using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex;
using Apex.MVVM;
using $safeprojectname$.Models;
using $safeprojectname$.Pages;

namespace $safeprojectname$.ViewModels
{
    /// <summary>
    /// The MusicViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class MusicViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicViewModel"/> class.
        /// </summary>
        public MusicViewModel()
        {
            Title = "Music";

            if(ApexBroker.CurrentExecutionContext == ExecutionContext.Design)
            {
                //  Add some design-time data.
                artists.Add("The Beatles");
                artists.Add("Pink Floyd");
            }
            else
            {
                
                //  Get the artists from the model.
                var zuneModel = ApexBroker.GetModel<IZuneModel>();
                foreach (var artist in zuneModel.GetArtists())
                    artists.Add(artist);
            }

        }

        private readonly ObservableCollection<string> artists = new ObservableCollection<string>();

        public ObservableCollection<string> Artists
        {
            get { return artists; }
        }

        private readonly NotifyingProperty SelectedArtistProperty = new NotifyingProperty("SelectedArtist",
            typeof(string), default(string));

        public string SelectedArtist
        {
            get { return (string) GetValue(SelectedArtistProperty); }
            set { SetValue(SelectedArtistProperty, value); }
        }
    }
}
