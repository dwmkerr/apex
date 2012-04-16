using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerSample
{
    /// <summary>
    /// The ViewBrokerSampleViewModel ViewModel class.
    /// </summary>
    public class ViewBrokerSampleViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBrokerSampleViewModel"/> class.
        /// </summary>
        public ViewBrokerSampleViewModel()
        {
            //  Create some devices.
            var ipad = new DeviceViewModel() { Name = "Apple iPad", Description = "The Apple iPad." };
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<DeviceViewModel> devices =
            new ObservableCollection<DeviceViewModel>();

        /// <summary>
        /// Gets the devices.
        /// </summary>
        public ObservableCollection<DeviceViewModel> Devices
        {
            get { return devices; }
        }

    }
}
