namespace Apex.MVVM
{
    /// <summary>
    /// CancelCommandEventArgs is sent during the command process, just
    /// before execution. It supplies the command parameter and can
    /// indicate that the command should be cancelled.
    /// </summary>
    public class CancelCommandEventArgs : CommandEventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CancelCommandEventArgs"/> command should be cancelled.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel { get; set; }
    }

    /// <summary>
    /// Typed CancelCommandEventArgs is sent during the command process, just
    /// before execution. It supplies the command parameter and can
    /// indicate that the command should be cancelled.
    /// </summary>
    public class CancelCommandEventArgs<TParameter> : CommandEventArgs<TParameter>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CancelCommandEventArgs"/> command should be cancelled.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel { get; set; }
    }
}