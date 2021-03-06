﻿using System;
using System.Collections.Generic;

namespace ZuneStyleApplication.Models
{
    /// <summary>
    /// The ZuneWindow Model interface.
    /// </summary>
    public interface IZuneModel
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
