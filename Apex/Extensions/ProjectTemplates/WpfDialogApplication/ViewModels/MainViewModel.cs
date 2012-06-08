using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using WpfDialogApplication.Models;

namespace WpfDialogApplication.ViewModels
{
    /// <summary>
    /// The main viewmodel class.
    /// </summary>
    public class MainViewModel : ViewModel<IAppModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            //  Wire up commands.
            SaveChangesCommand = new Command(DoSaveChangesCommand);
            CloseCommand = new Command(DoCloseCommand);
        }

        /// <summary>
        /// Set the viewmodel data from the model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override void FromModel(IAppModel model)
        {
            //  Set the title.
            Title = "My Application";

            //  Save these properties as the initial state.
            SaveInitialState();
        }

        /// <summary>
        /// Save the viewmodel data back to the model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override void ToModel(IAppModel model)
        {
        }
        
        /// <summary>
        /// The NotifyingProperty for the Title property.
        /// </summary>
        private readonly NotifyingProperty TitleProperty =
          new NotifyingProperty("Title", typeof(string), default(string));

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        /// <value>The value of Title.</value>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        
        /// <summary>
        /// Performs the SaveChanges command.
        /// </summary>
        /// <param name="parameter">The SaveChanges command parameter.</param>
        private void DoSaveChangesCommand(object parameter)
        {
        }

        /// <summary>
        /// Gets the SaveChanges command.
        /// </summary>
        /// <value>The value of .</value>
        public Command SaveChangesCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Performs the Close command.
        /// </summary>
        /// <param name="parameter">The Close command parameter.</param>
        private void DoCloseCommand(object parameter)
        {
        }

        /// <summary>
        /// Gets the Close command.
        /// </summary>
        /// <value>The value of .</value>
        public Command CloseCommand
        {
            get;
            private set;
        } 
    }
}
