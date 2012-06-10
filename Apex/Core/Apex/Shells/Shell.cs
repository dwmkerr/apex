using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Apex.MVVM;

namespace Apex.Shells
{
    /// <summary>
    /// In WPF, a shell is simply a window.
    /// </summary>
    public class Shell : Window, IShell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        public Shell()
        {
            //  Register the shell.
            ApexBroker.RegisterShell(this);
        }

        /// <summary>
        /// Minimizes the shell, if supported.
        /// </summary>
        public void DoMinimize()
        {
            //  Set the appropriate window state.
            WindowState = System.Windows.WindowState.Minimized;
        }

        /// <summary>
        /// Maximizes the shell, if supported.
        /// </summary>
        public void DoMaximize()
        {
            //  Set the appropriate window state.
            WindowState = System.Windows.WindowState.Maximized;
        }

        /// <summary>
        /// Restores the shell, if supported.
        /// </summary>
        public void DoRestore()
        {
            //  Set the appropriate window state.
            WindowState = System.Windows.WindowState.Normal;
        }

        /// <summary>
        /// Fullscreens the shell, if supported.
        /// </summary>
        public void DoFullscreen()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the shell, if supported.
        /// </summary>
        public void DoClose()
        {
            Close();
        }
    }
}
