namespace Apex.MVVM
{
    /// <summary>
    /// The CommandEventHandler delegate.
    /// </summary>
    public delegate void CommandEventHandler(object sender, CommandEventArgs args);

    /// <summary>
    /// The typed CommandEventHandler delegate.
    /// </summary>
    public delegate void CommandEventHandler<TParameter>(object sender, CommandEventArgs<TParameter> args);

    /// <summary>
    /// The CancelCommandEvent delegate.
    /// </summary>
    public delegate void CancelCommandEventHandler(object sender, CancelCommandEventArgs args);

    /// <summary>
    /// The typed CancelCommandEvent delegate.
    /// </summary>
    public delegate void CancelCommandEventHandler<TParameter>(object sender, CancelCommandEventArgs<TParameter> args);
}