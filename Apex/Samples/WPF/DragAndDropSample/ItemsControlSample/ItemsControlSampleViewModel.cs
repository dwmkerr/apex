using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace DragAndDropSample.ItemsControlSample
{
    /// <summary>
    /// The ItemsControlSampleViewModel ViewModel class.
    /// </summary>
    public class ItemsControlSampleViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsControlSampleViewModel"/> class.
        /// </summary>
        public ItemsControlSampleViewModel()
        {
            Group1.Add("Homer Simpson");
            Group1.Add("Marge Simpson");
            Group1.Add("Bart Simpson");
            Group1.Add("Lisa Simpson");
            Group1.Add("Maggie Simpson");

            Group2.Add("Mr Burns");
            Group2.Add("Mr Smithers");

            Group3.Add("Krusty");
            Group3.Add("Bubblebee Man");

            group4.Add("Itchy");
            group4.Add("Scratchy");
        }

        private ObservableCollection<string> group1 = new ObservableCollection<string>();
        private ObservableCollection<string> group2 = new ObservableCollection<string>();
        private ObservableCollection<string> group3 = new ObservableCollection<string>();
        private ObservableCollection<string> group4 = new ObservableCollection<string>();

        public ObservableCollection<string> Group1 { get { return group1; } }
        public ObservableCollection<string> Group2 { get { return group2; } }
        public ObservableCollection<string> Group3 { get { return group3; } }
        public ObservableCollection<string> Group4 { get { return group4; } }
    }
}
