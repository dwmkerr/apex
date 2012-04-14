using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{
    /// <summary>
    /// The view-viewmodel mapping.
    /// </summary>
    internal class ViewModelViewMapping
    {
        /// <summary>
        /// Gets or sets the type of the view model.
        /// </summary>
        /// <value>
        /// The type of the view model.
        /// </value>
        public Type ViewModelType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the view.
        /// </summary>
        /// <value>
        /// The type of the view.
        /// </value>
        public Type ViewType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the hint.
        /// </summary>
        /// <value>
        /// The hint.
        /// </value>
        public string Hint
        {
            get;
            set;
        }
    }

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
        public void RegisterViewForViewModel(Type viewModelType, Type viewType, string hint = null)
        {
            //  Register the mapping.
            viewModelViewMappings.Add(new ViewModelViewMapping()
            {
                ViewModelType = viewModelType,
                ViewType = viewType,
                Hint = hint
            });
        }

        /// <summary>
        /// Gets the view for view model.
        /// </summary>
        /// <param name="hint">The hint.</param>
        /// <returns>The view type for the view model type.</returns>
        public Type GetViewForViewModel(Type viewModelType, string hint = null)
        {
            return (from vmm in viewModelViewMappings
                    where vmm.ViewModelType.AssemblyQualifiedName == viewModelType.AssemblyQualifiedName
                    && vmm.Hint == hint select vmm.ViewType).FirstOrDefault();
        }

        /// <summary>
        /// A map of view model types to view types.
        /// </summary>
        private List<ViewModelViewMapping> viewModelViewMappings =
            new List<ViewModelViewMapping>();

        /// <summary>
        /// The global broker, generally used for all broker operations.
        /// </summary>
        private static ApexBroker globalBroker = new ApexBroker();

        /// <summary>
        /// Gets the global broker.
        /// </summary>
        public static ApexBroker GlobalBroker
        {
            get { return globalBroker; }
        }
    }
}
