using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{
    /// <summary>
    /// The Model Attribute marks a class as a model.
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class)]
    public class ModelAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttributeAttribute"/> class.
        /// </summary>
        public ModelAttribute()
        {
            //  Use the standard execution context.
            Context = ExecutionContext.Standard;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttribute"/> class.
        /// </summary>
        /// <param name="context">The execution context for the model.</param>
        public ModelAttribute(ExecutionContext context)
        {
            //  Store the execution context.
            Context = context;
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
