namespace Apex.MVVM
{
    /// <summary>
    /// Models can implement this interface to be given handlers
    /// to key life-cycle events.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Called to initialise a model.
        /// </summary>
        void OnInitialised();
    }
}
