using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{

    /// <summary>
    /// The Apex Broker can be used to get views for viewmodels.
    /// </summary>
    public class ApexBroker
    {
        /// <summary>
        /// Registers the view for view model.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="viewType">Type of the view.</param>
        public void RegisterViewForViewModel(Type viewModelType, Type viewType)
        {
            //  Register the mapping.
            mapViewModelTypeToViewType[viewModelType] = viewType;
        }

        /// <summary>
        /// A map of view model types to view types.
        /// </summary>
        private Dictionary<Type, Type> mapViewModelTypeToViewType
            = new Dictionary<Type, Type>();
    }
}
