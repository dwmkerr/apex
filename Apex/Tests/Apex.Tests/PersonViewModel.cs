using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace Apex.Tests
{
    /// <summary>
    /// A ViewModel for a Person.
    /// </summary>
    public class PersonViewModel : ViewModel
    {
        /// <summary>
        /// The first name property.
        /// </summary>
        private readonly NotifyingProperty FirstNameProperty =
            new NotifyingProperty("FirstName", typeof (string), string.Empty);

        /// <summary>
        /// The second name property.
        /// </summary>
        private readonly NotifyingProperty SecondNameProperty =
            new NotifyingProperty("SecondName", typeof (string), string.Empty);

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the second.
        /// </summary>
        /// <value>
        /// The name of the second.
        /// </value>
        public string SecondName
        {
            get { return (string)GetValue(SecondNameProperty); }
            set { SetValue(SecondNameProperty, value); }
        }
    }
}
