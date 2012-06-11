using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Apex.MVVM;

namespace Apex.Shells
{
    /// <summary>
    /// A Shell Window for WPF.
    /// </summary>
    public class ShellWindow : Window, IShell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellWindow"/> class.
        /// </summary>
        public ShellWindow()
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
