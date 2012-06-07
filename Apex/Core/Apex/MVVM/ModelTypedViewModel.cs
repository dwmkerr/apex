using System.ComponentModel;
using System.Windows.Threading;
using System;

namespace Apex.MVVM
{
    /// <summary>
    /// A Model-Typed ViewModel is a ViewModel designed to present data 
    /// from a specific model type.
    /// </summary>
    public abstract class ViewModel<TModel> : ViewModel
    {
        /// <summary>
        /// Sets the ViewModel up from a Model instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public abstract void FromModel(TModel model);

        /// <summary>
        /// Saves the ViewModel data back into the model.
        /// </summary>
        /// <param name="model">The model.</param>
        public abstract void ToModel(TModel model);
    }
}