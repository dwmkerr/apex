using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.MVVM
{
    /// <summary>
    /// The View attribute marks a class as a View . This is used
    /// to allow the Apex SDK to help build Views and ViewModels.
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class)]
    public class ViewAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelAttribute"/> class.
        /// </summary>
        public ViewAttribute()
        {
            //  Assume the ViewModel is simply an object.
            ViewModelType = typeof(object);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAttribute"/> class.
        /// </summary>
        /// <param name="viewModelType">Type of the associated ViewModel.</param>
        public ViewAttribute(Type viewModelType)
        {
            //  Store the view model type.
            ViewModelType = viewModelType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAttribute"/> class.
        /// </summary>
        /// <param name="viewModelType">Type of the associated ViewModel.</param>
        /// <param name="hint">The hint.</param>
        public ViewAttribute(Type viewModelType, string hint)
        {
            //  Store the view model type.
            ViewModelType = viewModelType;
            Hint = hint;
        }

        /// <summary>
        /// Gets the type of the view model.
        /// </summary>
        /// <value>
        /// The type of the view model.
        /// </value>
        public Type ViewModelType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the hint.
        /// </summary>
        public string Hint
        {
            get;
            private set;
        }
    }
}
