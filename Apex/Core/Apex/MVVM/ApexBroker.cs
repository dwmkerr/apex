using System;
using System.Linq;
using System.Collections.Generic;

namespace Apex.MVVM
{
    /// <summary>
    /// The <see cref="ApexBroker"/> ApexBroker Singleton class.
    /// </summary>
    public static class ApexBroker
    {
        /// <summary>
        /// Registers the model.
        /// </summary>
        /// <typeparam name="TModelInterface">The model interface type.</typeparam>
        /// <param name="model">The model.</param>
        public static void RegisterModel<TModelInterface>(object model)
        {
            modelInterfaceToModelDictionary[typeof(TModelInterface)] = model;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <typeparam name="TModelInterface">The type of the model interface.</typeparam>
        /// <returns>The model.</returns>
        public static TModelInterface GetModel<TModelInterface>()
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
        public static void RegisterViewForViewModel(Type viewModelType, Type viewType, string hint = null)
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
        public static void RegisterApplicationHost(IApplicationHost applicationHost)
        {
            //  Ensure we don't already have an application host registered.
            if (ApexBroker.applicationHost != null)
                throw new InvalidOperationException("An application host has already been registered. Only one application host can be registered.");

            //  Store the application host.
            ApexBroker.applicationHost = applicationHost;
        }

        /// <summary>
        /// Gets the application host.
        /// </summary>
        /// <returns></returns>
        public static IApplicationHost GetApplicationHost()
        {
            //  Error check.
            if (applicationHost == null)
                throw new InvalidOperationException("No application host has been registered.");

            //  Return the application host.
            return applicationHost;
        }

        /// <summary>
        /// Gets the view for view model.
        /// </summary>
        /// <param name="hint">The hint.</param>
        /// <returns>The view type for the view model type.</returns>
        public static Type GetViewForViewModel(Type viewModelType, string hint = null)
        {
            return (from vmm in viewModelViewMappings
                    where vmm.ViewModelType.AssemblyQualifiedName == viewModelType.AssemblyQualifiedName
                    && vmm.Hint == hint
                    select vmm.ViewType).FirstOrDefault();
        }

        /// <summary>
        /// A map of view model types to view types.
        /// </summary>
        private static List<ViewModelViewMapping> viewModelViewMappings =
            new List<ViewModelViewMapping>();

        /// <summary>
        /// The map of model interfaces to model instances.
        /// </summary>
        private static Dictionary<Type, object> modelInterfaceToModelDictionary =
            new Dictionary<Type, object>();
        
        /// <summary>
        /// Gets the application host.
        /// </summary>
        private static IApplicationHost applicationHost;
        
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
    }
}
