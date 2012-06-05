using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

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
        /// Registers the model.
        /// </summary>
        /// <typeparam name="TModelInterface">The model interface type.</typeparam>
        /// <param name="model">The model.</param>
        public void RegisterModel<TModelInterface>(object model)
        {
            modelInterfaceToModelDictionary[typeof(TModelInterface)] = model;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <typeparam name="TModelInterface">The type of the model interface.</typeparam>
        /// <returns>The model.</returns>
        public TModelInterface GetModel<TModelInterface>()
        {
            try
            {
                return (TModelInterface)modelInterfaceToModelDictionary[typeof(TModelInterface)];
            }
            catch
            {
                throw new InvalidOperationException("The Model Type " + typeof(TModelInterface).Name + " has not been registered.");
            }
        }

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
        /// Registers the application host.
        /// </summary>
        /// <param name="applicationHost">The application host.</param>
        public void RegisterApplicationHost(IApplicationHost applicationHost)
        {
            //  Store the application host.
            this.applicationHost = applicationHost;
        }

        /// <summary>
        /// Gets the application host.
        /// </summary>
        /// <returns></returns>
        public IApplicationHost GetApplicationHost()
        {
            //  Error check.
            if(applicationHost == null)
                throw new InvalidOperationException("No application host has been registered.");

            //  Return the application host.
            return applicationHost;
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
                    && vmm.Hint == hint
                    select vmm.ViewType).FirstOrDefault();
        }

        /// <summary>
        /// A map of view model types to view types.
        /// </summary>
        private List<ViewModelViewMapping> viewModelViewMappings =
            new List<ViewModelViewMapping>();

        /// <summary>
        /// The map of model interfaces to model instances.
        /// </summary>
        private Dictionary<Type, object> modelInterfaceToModelDictionary = 
            new Dictionary<Type, object>();

        /// <summary>
        /// The global broker, generally used for all broker operations.
        /// </summary>
        private static ApexBroker globalBroker;

        /// <summary>
        /// Gets the application host.
        /// </summary>
        private IApplicationHost applicationHost;

        /// <summary>
        /// The sync object.
        /// </summary>
        private static object syncObject = new object();

        /// <summary>
        /// Gets the global broker.
        /// </summary>
        public static ApexBroker GlobalBroker
        {
            get 
            { 
                //  Lock on the sync object.
                lock (syncObject)
                {
                    if (globalBroker == null)
                    {
                        //  Create the global broker.
                        globalBroker = new ApexBroker();
                    }
                }

                //  Return the global broker.
                return globalBroker; 
            }
        }
    }
}
