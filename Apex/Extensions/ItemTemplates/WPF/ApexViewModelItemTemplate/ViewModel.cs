using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace $rootnamespace$
{
    /// <summary>
    /// The $safeitemrootname$ ViewModel class.
    /// </summary>
    [ViewModel]
	public class $safeitemrootname$ : ViewModel
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="$safeitemrootname$"/> class.
        /// </summary>
        public $safeitemrootname$ ()
	    {
            //  TODO: Use the following snippets to help build viewmodels:
            //      apexnp - Creates a Notifying Property
            //      apexc - Creates a Command.
            $if$ ($CreateExampleCommand$ == 1)
            //  Create the example command.
            ExampleCommand = new Command(DoExampleCommand);$endif$
	    } 
        $if$ ($CreateExampleNotifyingProperty$ == 1)    
        /// <summary>
        /// Declare the Example property.
        /// </summary>
        private NotifyingProperty ExampleProperty =
          new NotifyingProperty("Example", typeof(string), default(string));

        /// <summary>
        /// Gets or sets the example.
        /// </summary>
        /// <value>
        /// The example.
        /// </value>
        public string Example
        {
            get { return (string)GetValue(ExampleProperty); }
            set { SetValue(ExampleProperty, value); }
        }$endif$    
        $if$ ($CreateExampleObservableCollection$ == 1)
        /// <summary>
        /// The example collection.
        /// </summary>
        private ObservableCollection<string> exampleCollection = 
            new ObservableCollection<string>();

        /// <summary>
        /// Gets the example collection.
        /// </summary>
        public ObservableCollection<string> ExampleCollection
        {
            get { return exampleCollection; }
        }$endif$
        $if$ ($CreateExampleCommand$ == 1)
        /// <summary>
        /// Performs the example command.
        /// </summary>
        private void DoExampleCommand()
        {
        }

        /// <summary>
        /// Gets the example command.
        /// </summary>
        public Command ExampleCommand
        {
            get;
            private set;
        }$endif$
	}
}
