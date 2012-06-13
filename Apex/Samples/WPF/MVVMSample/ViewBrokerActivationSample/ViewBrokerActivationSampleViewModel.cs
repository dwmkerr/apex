using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerActivationSample
{
    /// <summary>
    /// The ViewBrokerSampleViewModel ViewModel class.
    /// </summary>
    public class ViewBrokerActivationSampleViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBrokerActivationSampleViewModel"/> class.
        /// </summary>
        public ViewBrokerActivationSampleViewModel()
        {
            //  Add the page view models.
            pageViewModels.Add(new Page1ViewModel());
            pageViewModels.Add(new Page2ViewModel());
        }

        private ObservableCollection<ViewModel> pageViewModels = new ObservableCollection<ViewModel>();

        public ObservableCollection<ViewModel> PageViewModels
        {
            get { return pageViewModels; }
        }

        private readonly  NotifyingProperty selectedPageViewModelProperty = new NotifyingProperty("SelectedPageViewModel", typeof(ViewModel), null);

        public ViewModel SelectedPageViewModel
        {
            get { return (ViewModel)GetValue(selectedPageViewModelProperty); }
            set { SetValue(selectedPageViewModelProperty, value); }
        }
    }
}
