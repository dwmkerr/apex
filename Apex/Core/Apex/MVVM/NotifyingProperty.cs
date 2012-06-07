using System;

namespace Apex.MVVM
{
    /// <summary>
    /// The notifying property changed event args.
    /// </summary>
    public class NotifyingPropertyChangedArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyingPropertyChangedArgs"/> class.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public NotifyingPropertyChangedArgs(object oldValue, object newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Gets the old value.
        /// </summary>
        public object OldValue { get; private set; }

        /// <summary>
        /// Gets the new value.
        /// </summary>
        public object NewValue { get; private set; }
    }

    /// <summary>
    /// Delegat for the notifying property changed event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The args.</param>
    public delegate void NotifyingPropertyChangedEvent(object sender, NotifyingPropertyChangedArgs args);

    /// <summary>
    /// The NotifyingProperty class - represents a property of a viewmodel that
    /// can be wired into the notification system.
    /// </summary>
    public class NotifyingProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyingProperty"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public NotifyingProperty(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public void SetValue(object newValue)
        {
            //  Store the old value.
            var oldValue = Value;

            //  Is the value different?
            if(oldValue != newValue)
            {
                //  Set the new value.
                Value = newValue;

                //  Fire the property changed event.
                FireNotifyingPropertyChanged(oldValue, newValue);
            }
        }

        /// <summary>
        /// Saves the initial state.
        /// </summary>
        public void SaveInitialState()
        {
            //  Clone the value into the initial state.
            initialState = Value;
        }

        /// <summary>
        /// Fires the notifying property changed event.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void FireNotifyingPropertyChanged(object oldValue, object newValue)
        {
            //  Fire the event (thread safe).
            var theEvent = NotifyingPropertyChanged;
            if(theEvent != null)
                theEvent(this, new NotifyingPropertyChangedArgs(oldValue, newValue));
        }

        /// <summary>
        /// The initial state value.
        /// </summary>
        private object initialState;

        /// <summary>
        /// Occurs when a notifying property is changed.
        /// </summary>
        public event NotifyingPropertyChangedEvent NotifyingPropertyChanged;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }
    }
}