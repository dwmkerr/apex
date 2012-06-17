using System;
using System.Collections.Generic;

namespace $safeprojectname$.Models
{
    /// <summary>
    /// The $safeprojectname$ Model interface.
    /// </summary>
    public interface I$safeprojectname$Model
    {
        /// <summary>
        /// Gets the ablums.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAlbums();

        /// <summary>
        /// Gets the artists.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetArtists();

        /// <summary>
        /// Gets the tracks.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetTracks();
    }
}
