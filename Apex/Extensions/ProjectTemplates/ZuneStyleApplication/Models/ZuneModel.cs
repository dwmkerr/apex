using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace ZuneStyleApplication.Models
{
    [Model(typeof(IZuneModel))]
    public class ZuneModel : IModel, IZuneModel
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
        }

        /// <summary>
        /// Gets the ablums.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAblums()
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
