using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex;
using Apex.MVVM;

namespace $safeprojectname$.Models
{
    /// <summary>
    /// The $safeprojectname$ Model. Can be accessed via ApexBroker.GetModel
    /// via the interface I$safeprojectname$Model.
    /// </summary>
    [Model]
    public class $safeprojectname$Model : IModel, I$safeprojectname$Model
    {
        /// <summary>
        /// Called to initialise a model.
        /// </summary>
        public void OnInitialised()
        {
            //  TODO: Initialise your model here.
        }

        /// <summary>
        /// Gets the artists.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetArtists()
        {
            yield return "John Coltrain";
            yield return "Miles Davis";
            yield return "Joe Pass";
        }

        /// <summary>
        /// Gets the ablums.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAlbums()
        {
            yield return "Giant Steps";
        }

        /// <summary>
        /// Gets the tracks.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTracks()
        {
            yield return "Track 1";
        }
    }
}
