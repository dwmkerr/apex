using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Shells
{
    /// <summary>
    /// An IShell interface represents a shell for an MVVM application.
    /// This could be a top level element in a web page (silverlight)
    /// a window (wpf) or a page in WP7.
    /// </summary>
    public interface IShell
    {
        /// <summary>
        /// Minimizes the shell, if supported.
        /// </summary>
        void DoMinimize();

        /// <summary>
        /// Maximizes the shell, if supported.
        /// </summary>
        void DoMaximize();

        /// <summary>
        /// Restores the shell, if supported.
        /// </summary>
        void DoRestore();

        /// <summary>
        /// Fullscreens the shell, if supported.
        /// </summary>
        void DoFullscreen();

        /// <summary>
        /// Closes the shell, if supported.
        /// </summary>
        void DoClose();
    }
}
