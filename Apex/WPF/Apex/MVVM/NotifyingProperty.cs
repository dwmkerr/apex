using System;

namespace Apex.MVVM
{
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