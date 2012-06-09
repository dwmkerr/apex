using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{
    /// <summary>
    /// The Model Attribute marks a class as a model, which must implement the specified interface.
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class)]
    public class ModelAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttributeAttribute"/> class.
        /// </summary>
        private ModelAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttribute"/> class.
        /// </summary>
        /// <param name="modelInterfaceType">The Model Interface this Model implements.</param>
        public ModelAttribute(Type modelInterfaceType)
        {
            //  Store the view model type.
            ModelInterfaceType = modelInterfaceType;

            //  Use the standard execution context.
            Context = ExecutionContext.Standard;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttribute"/> class.
        /// </summary>
        /// <param name="modelInterfaceType">Type of the model interface.</param>
        /// <param name="context">The execution context for the model.</param>
        public ModelAttribute(Type modelInterfaceType, ExecutionContext context)
        {
            //  Store the view model type.
            ModelInterfaceType = modelInterfaceType;

            //  Store the execution context.
            Context = context;
        }

        /// <summary>
        /// Gets the type of the model interface.
        /// </summary>
        /// <value>
        /// The type of the model interface.
        /// </value>
        public Type ModelInterfaceType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the execution context for the model.
        /// </summary>
        public ExecutionContext Context
        {
            get;
            private set;
        }
    }
}
