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
        bool CanMinimize { get; }

        bool CanMaximize { get; }

        bool CanFullscreen { get; }

        void Minimize();

        void Maximize();

        void Restore();

        void Fullscreen();

        void Close();
    }
}
