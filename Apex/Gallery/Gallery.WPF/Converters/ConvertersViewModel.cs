using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace Gallery.Converters
{
    [ViewModel]
    public class ConvertersViewModel : GalleryItemViewModel
    {
        public ConvertersViewModel()
        {
            Title = "Converters";
        }

        
        /// <summary>
        /// The NotifyingProperty for the ExampleBool1 property.
        /// </summary>
        private readonly NotifyingProperty ExampleBool1Property =
          new NotifyingProperty("ExampleBool1", typeof(bool), default(bool));

        /// <summary>
        /// Gets or sets ExampleBool1.
        /// </summary>
        /// <value>The value of ExampleBool1.</value>
        public bool ExampleBool1
        {
            get { return (bool)GetValue(ExampleBool1Property); }
            set { SetValue(ExampleBool1Property, value); }
        }
    }
}
