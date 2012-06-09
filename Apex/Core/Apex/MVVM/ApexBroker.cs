using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Apex.MVVM
{
    /// <summary>
    /// The <see cref="ApexBroker"/> ApexBroker Singleton class.
    /// </summary>
    public static class ApexBroker
    {
        /// <summary>
        /// Initialises the ApexBroker, allowing it to be used.
        /// </summary>
        public static void Initialise()
        {
            //  Always lock for this method.
            lock (syncLock)
            {
                //  We may have already been initialised.
                if (isInitialised)
                    return;
            
                //  Find every type that has the Model attribute.
                var modelTypes = from a in AppDomain.CurrentDomain.GetAssemblies()
                                 where a.GlobalAssemblyCache == false && a.IsDynamic == false
                                 from t in a.GetExportedTypes()
                                 where t.GetCustomAttributes(typeof(ModelAttribute), false).Any()
                                 select new
                                 {
                                     ModelType = t,
                                     ModelAttribute = (ModelAttribute)t.GetCustomAttributes(typeof(ModelAttribute), false).Single()
                                 };

                //  Go through each model type, construct it and register it as a model.
                foreach (var modelType in modelTypes)
                {
                    //  Create the model instance.
                    var modelInstance = Activator.CreateInstance(modelType.ModelType);

                    //  Register the model instance as a model of the specified model interface type.
                    modelInterfaceToModelDictionary[modelType.ModelAttribute.ModelInterfaceType] = modelInstance;
                }

                //  We're now initialised.
                isInitialised = true;
            }
        }

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
            //  We must be initialised for this to work.
            EnsureInitialised();

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
            //  We must be initialised for this to work.
            EnsureInitialised();

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
            //  We must be initialised for this to work.
            EnsureInitialised();

            return (from vmm in viewModelViewMappings
                    where vmm.ViewModelType.AssemblyQualifiedName == viewModelType.AssemblyQualifiedName
                    && vmm.Hint == hint
                    select vmm.ViewType).FirstOrDefault();
        }

        /// <summary>
        /// Ensures the broker is initialised.
        /// </summary>
        private static void EnsureInitialised()
        {
            //  If we're initialised, we're done.
            if (isInitialised)
                return;

            //  Initialise.
            Initialise();
        }

        /// <summary>
        /// Determines the execution context.
        /// </summary>
        /// <returns>The current execution context.</returns>
        private static ExecutionContext DetermineExecutionContext()
        {
            //  Are we running in the visual studio IDE?
            if (Assembly.GetExecutingAssembly().FullName.Contains("devenv"))
                return ExecutionContext.Design;
            
            //  Test assemblies we know about.
            var unitTestFrameworkMS = @"microsoft.visualstudio.qualitytools.unittestframework";
            var unitTestFrameworkNunit = @"nunit.framework";
            bool isUnitTest = AppDomain.CurrentDomain.GetAssemblies().Any(a =>
                (a.FullName.ToLowerInvariant().StartsWith(unitTestFrameworkMS) ||
                a.FullName.ToLowerInvariant().StartsWith(unitTestFrameworkNunit)));

            //  If we're not in a unit test, we're in the designer.
            if (isUnitTest)
                return ExecutionContext.Test;

            //  We're just running code.
            return ExecutionContext.Standard;
        }

        /// <summary>
        /// A sync lock for thread safety.
        /// </summary>
        private static object syncLock = new object();

        /// <summary>
        /// A boolean to determine whether the broker is initialised.
        /// </summary>
        private static bool isInitialised;

        /// <summary>
        /// The current execution context.
        /// </summary>
        private static ExecutionContext? currentExecutionContext;

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

        /// <summary>
        /// Gets the current execution context.
        /// </summary>
        public static ExecutionContext CurrentExecutionContext
        {
            get
            {
                //  If the current execution context has not been set, determine it.
                if (currentExecutionContext == null)
                    currentExecutionContext = DetermineExecutionContext();

                //  Return the current execution context.
                return currentExecutionContext.Value;
            }
        }
    }
}
