namespace Apex.MVVM
{
    /// <summary>
    /// Views can implement this interface to be given handlers
    /// to key life-cycle events.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Called when the view is activated.
        /// </summary>
        void OnActivated();

        /// <summary>
        /// Called when the view is deactivated.
        /// </summary>
        void OnDeactivated();
    }
}
