using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using System.Collections.ObjectModel;

namespace ControlsSample
{
    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            Samples.Add(new Sample() { Name = "Apex Grid", View = new Samples.ApexGrid() });
            Samples.Add(new Sample() { Name = "Cross Button", View = new Samples.CrossButton() });
            Samples.Add(new Sample() { Name = "Padded Grid", View = new Samples.PaddedGrid() });
            Samples.Add(new Sample() { Name = "Enum Combo Box", View = new Samples.EnumComboBox() });
        }

        /// <summary>
        /// The set of samples.
        /// </summary>
        private ObservableCollection<Sample> samples = new ObservableCollection<Sample>();

        /// <summary>
        /// Gets the samples.
        /// </summary>
        public ObservableCollection<Sample> Samples
        {
            get { return samples; }
        }


        /// <summary>
        /// The selected sample property.
        /// </summary>
        private NotifyingProperty SelectedSampleProperty =
          new NotifyingProperty("SelectedSample", typeof(Sample), default(Sample));

        /// <summary>
        /// Gets or sets the selected sample.
        /// </summary>
        /// <value>
        /// The selected sample.
        /// </value>
        public Sample SelectedSample
        {
            get { return (Sample)GetValue(SelectedSampleProperty); }
            set { SetValue(SelectedSampleProperty, value); }
        }             
                
    }
}
