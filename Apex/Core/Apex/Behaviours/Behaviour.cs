
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Apex.Behaviours
{
    /// <summary>
    /// Represents an attachable behaviour.
    /// </summary>
    /// <typeparam name="TElement">The type of the element this behaviour can be attached to.</typeparam>
    public abstract class Behaviour<TElement> : IBehaviour where TElement : FrameworkElement
    {
        /// <summary>
        /// Attaches the behaviour to the specified framework element.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        public void Attach(FrameworkElement frameworkElement)
        {
            OnAttached((TElement)frameworkElement);
        }

        /// <summary>
        /// Detaches the behaviour to the the specified framework element.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        public void Detach(FrameworkElement frameworkElement)
        {
            OnDetached((TElement)frameworkElement);
        }

        /// <summary>
        /// Called when the behaviour is attached.
        /// </summary>
        /// <param name="element">The element the behaviour is attached to.</param>
        public abstract void OnAttached(TElement element);

        /// <summary>
        /// Called when behaviour is detached.
        /// </summary>
        /// <param name="element">The element the behaviour is detached from.</param>
        public abstract void OnDetached(TElement element);
    }
}
