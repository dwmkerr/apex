using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Apex.Helpers;
using Apex.Shells;
using Apex.MVVM;

namespace Apex
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

                //  Enumerate all types to search.
                var typesToSearch = AssembliesHelper.GetTypesInDomain().ToList();
            
                //  Find every type that has the Model attribute.
                var modelTypes = from t in typesToSearch
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

                    //  If the model implements the IModel interface, notify it that it can be initialised.
                    if(modelInstance is IModel)
                        ((IModel)modelInstance).OnInitialised();

                    //  Store the model.
                    modelInstances.Add(modelInstance);
                }

                //  Find every type that has the View attribute.
                var viewTypes = from t in typesToSearch
                                 where t.GetCustomAttributes(typeof(ViewAttribute), false).Any()
                                 select new
                                 {
                                     ViewType = t,
                                     ViewAttribute = (ViewAttribute)t.GetCustomAttributes(typeof(ViewAttribute), false).Single()
                                 };

                //  Register each view to viewmodel.
                foreach (var viewType in viewTypes)
                {
                    //  Register the mapping.
                    RegisterViewForViewModel(viewType.ViewAttribute.ViewModelType, viewType.ViewType);
                }

                //  We're now initialised.
                isInitialised = true;
            }
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <returns>The model instance.</returns>
        public static TModel GetModel<TModel>()
        {
            //  We must be initialised for this to work.
            EnsureInitialised();

            try
            {
                return (TModel) modelInstances.Single(m => m is TModel);
            }
            catch
            {
                throw new InvalidOperationException("The Model Type " + typeof(TModel).Name + " has not been registered.");
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
        /// Registers the shell.
        /// </summary>
        /// <param name="shell">The shell.</param>
        public static void RegisterShell(IShell shell)
        {
            //  Ensure we don't already have a shell registered.
            if (ApexBroker.shell != null)
                throw new InvalidOperationException("A shell has already been registered. Only shell can be registered.");

            //  Store the shell.
            ApexBroker.shell = shell;
        }

        /// <summary>
        /// Registers a service. Generally a Service is some kind of object that implements an interface,
        /// for example 'ILogService' or 'IMessagingService'.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="serviceInstance">The service instance.</param>
        public static void RegisterService<TService>(TService serviceInstance)
        {
            lock(syncLock)
            {
                if(serviceTypesToInstances.ContainsKey(typeof(TService)))
                    throw new InvalidOperationException("A Service of this type has already been registered.");
                serviceTypesToInstances[typeof (TService)] = serviceInstance;
            }
        }

        /// <summary>
        /// Gets the service based on the service type, such as 'ILogService' or 'IMessagingService'.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>The service instance.</returns>
        public static TService GetService<TService>()
        {
            TService instance;

            lock(syncLock)
            {
                instance = (TService)serviceTypesToInstances[typeof(TService)];
            }

            return instance;
        }

        /// <summary>
        /// Gets the shell host.
        /// </summary>
        /// <returns>The registered shell.</returns>
        public static IShell GetShell()
        {
            //  We must be initialised for this to work.
            EnsureInitialised();

            //  Error check.
            if (shell == null)
                throw new InvalidOperationException("No shell has been registered.");

            //  Return the application host.
            return shell;
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

#if SILVERLIGHT
            //  We can check the designer properties in Silverlight to
            //  determine whether we're in the desinger.
            if(DesignerProperties.IsInDesignTool)
                return ExecutionContext.Design;
#else
            //  We can check the IsInDesignModeProperty property in WPF to
            //  determine whether we're in the desinger.
            var prop = DesignerProperties.IsInDesignModeProperty;
            if((bool)DependencyPropertyDescriptor
                .FromProperty(prop, typeof(FrameworkElement))
                .Metadata.DefaultValue == true)
                return ExecutionContext.Design;
#endif
            
            //  Test assemblies we know about.
            var unitTestFrameworkMS = @"microsoft.visualstudio.qualitytools.unittestframework";
            var unitTestFrameworkNunit = @"nunit.framework";
            bool isUnitTest = AssembliesHelper.GetDomainAssemblies().Any(a =>
                (a.FullName.ToLower().StartsWith(unitTestFrameworkMS) ||
                a.FullName.ToLower().StartsWith(unitTestFrameworkNunit)));

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
        /// The model instances.
        /// </summary>
        private static List<object> modelInstances =
            new List<object>();

        /// <summary>
        /// Dictionary of service types to service instances.
        /// </summary>
        private static Dictionary<Type, object> serviceTypesToInstances = new Dictionary<Type, object>(); 

        /// <summary>
        /// The shell.
        /// </summary>
        private static IShell shell;
        
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


    /// <summary>
    /// An ExecutionContext identifies how an assembly is running - whether it is standard,
    /// in the visual studio designer, or as a unit test.
    /// </summary>
    public enum ExecutionContext
    {
        /// <summary>
        /// The code is executing.
        /// </summary>
        Standard,

        /// <summary>
        /// The code is executing, but in the context of the visual studio designer.
        /// </summary>
        Design,

        /// <summary>
        /// The code is executing, but in the context of a unit test.
        /// </summary>
        Test
    }
}
