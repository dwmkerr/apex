using System.ComponentModel;

namespace Apex.MVVM
{
    /// <summary>
    /// Standard viewmodel class base, simply allows property change notifications to be sent.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public virtual void NotifyPropertyChanged(string propertyName)
        {
            //  Store the event handler - in case it changes between
            //  the line to check it and the line to fire it.
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            //  If the event has been subscribed to, fire it.
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets the value of a notifying property.
        /// </summary>
        /// <param name="notifyingProperty">The notifying property.</param>
        /// <returns>The value of the notifying property.</returns>
        protected object GetValue(NotifyingProperty notifyingProperty)
        {
            return notifyingProperty.Value;
        }

        /// <summary>
        /// Sets the value of the notifying property.
        /// </summary>
        /// <param name="notifyingProperty">The notifying property.</param>
        /// <param name="value">The value to set.</param>
        protected void SetValue(NotifyingProperty notifyingProperty, object value)
        {
            //  Call SetValue without forcing an update.
            SetValue(notifyingProperty, value, false);
        }

        /// <summary>
        /// Sets the value of the notifying property.
        /// </summary>
        /// <param name="notifyingProperty">The notifying property.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="forceUpdate">if set to <c>true</c> NotifyPropertyChanged will be called
        /// regardless of whether the new value is different to the old one.</param>
        protected void SetValue(NotifyingProperty notifyingProperty, object value, bool forceUpdate)
        {
            //  We'll only set the value and notify that it has changed if the
            //  value is different - or if we are forcing an update.
            if (notifyingProperty.Value != value || forceUpdate)
            {
                //  Set the value.
                notifyingProperty.Value = value;

                //  Notify that the property has changed.
                NotifyPropertyChanged(notifyingProperty.Name);
            }
        }
    }
}