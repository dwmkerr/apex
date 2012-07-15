using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace Gallery.Behaviours.ListViewItemContextMenuBehaviour
{
    public class PersonViewModel : ViewModel
    {
        
        /// <summary>
        /// The NotifyingProperty for the FirstName property.
        /// </summary>
        private readonly NotifyingProperty FirstNameProperty =
          new NotifyingProperty("FirstName", typeof(string), default(string));

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <value>The value of FirstName.</value>
        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        
        /// <summary>
        /// The NotifyingProperty for the LastName property.
        /// </summary>
        private readonly NotifyingProperty LastNameProperty =
          new NotifyingProperty("LastName", typeof(string), default(string));

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <value>The value of LastName.</value>
        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }
    }
}
