
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Apex.Behaviours
{

    /// <summary>
    /// Implement this interface in a Behaviour class to allow it to be attached or detached.
    /// </summary>
    public interface IBehaviour
    {
        /// <summary>
        /// Attaches the behaviour to the specified framework element.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        void Attach(FrameworkElement frameworkElement);

        /// <summary>
        /// Detaches the behaviour to the the specified framework element.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        void Detach(FrameworkElement frameworkElement);
    }
}
