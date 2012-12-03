using System;

namespace Apex.MVVM
{
    /// <summary>
    /// CommandEventArgs, event arguments for a command event, which also stores the command
    /// parameter.
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        public object Parameter { get; set; }
    }

    /// <summary>
    /// Typed CommandEventArgs, event arguments for a command event, which also stores the command
    /// parameter.
    /// </summary>
    public class CommandEventArgs<TParameter> : EventArgs
    {
        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        public TParameter Parameter { get; set; }
    }
}