using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Gallery.Controls.TabbedDocumentInterface
{
    public class TabbedDocumentInterfaceViewModel : GalleryItemViewModel
    {
        public TabbedDocumentInterfaceViewModel()
        {
            Title = "TabbedDocumentInterface";

            //  Create the AddDocument Command.
            AddDocumentCommand = new Command(DoAddDocumentCommand);
        }

        private int counter = 1;
        
        /// <summary>
        /// Performs the AddDocument command.
        /// </summary>
        /// <param name="parameter">The AddDocument command parameter.</param>
        private void DoAddDocumentCommand(object parameter)
        {
            Documents.Add(string.Format("Document {0}", counter++));
        }

        /// <summary>
        /// Gets the AddDocument command.
        /// </summary>
        /// <value>The value of .</value>
        public Command AddDocumentCommand
        {
            get;
            private set;
        }
        
        /// <summary>
        /// The Documents observable collection.
        /// </summary>
        private readonly ObservableCollection<string> DocumentsProperty =
          new ObservableCollection<string>();

        /// <summary>
        /// Gets the Documents observable collection.
        /// </summary>
        /// <value>The Documents observable collection.</value>
        public ObservableCollection<string> Documents
        {
            get { return DocumentsProperty; }
        }
    }
}
