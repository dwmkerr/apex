using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Gallery.Behaviours.ListViewItemContextMenuBehaviour
{
    public class ListViewItemContextMenuBehaviourViewModel : GalleryItemViewModel
    {
        public ListViewItemContextMenuBehaviourViewModel()
        {
            Title = "ListViewItemContextMenuBehaviour";

            People.Add(new PersonViewModel() { FirstName = "Homer", LastName = "Simpson" });
            People.Add(new PersonViewModel() { FirstName = "Marge", LastName = "Simpson" });
            People.Add(new PersonViewModel() { FirstName = "Bart", LastName = "Simpson" });
            People.Add(new PersonViewModel() { FirstName = "Lisa", LastName = "Simpson" });
            People.Add(new PersonViewModel() { FirstName = "Maggie", LastName = "Simpson" });
        }

        
        /// <summary>
        /// The People observable collection.
        /// </summary>
        private ObservableCollection<PersonViewModel> PeopleProperty =
          new ObservableCollection<PersonViewModel>();

        /// <summary>
        /// Gets the People observable collection.
        /// </summary>
        /// <value>The People observable collection.</value>
        public ObservableCollection<PersonViewModel> People
        {
            get { return PeopleProperty; }
        }
    }
}
