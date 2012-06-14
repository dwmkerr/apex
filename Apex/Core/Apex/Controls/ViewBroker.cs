using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Apex.MVVM;
using System.ComponentModel;
using System.Reflection;

namespace Apex.Controls
{
    /// <summary>
    /// A ViewBroker takes a ViewModel and shows the appropriate View.
    /// </summary>
    public class ViewBroker : ContentControl
    {
        /// <summary>
        /// Called when the <see cref="P:System.Windows.Controls.ContentControl.Content"/> property changes.
        /// </summary>
        /// <param name="oldContent">The old value of the <see cref="P:System.Windows.Controls.ContentControl.Content"/> property.</param>
        /// <param name="newContent">The new value of the <see cref="P:System.Windows.Controls.ContentControl.Content"/> property.</param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            //  Call the base.
            base.OnContentChanged(oldContent, newContent);

            //  The first time we get this, it'll be setting the default content.
            if (defaultContent == null && newContent != null)
                defaultContent = newContent;
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes 
        /// call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  Set the template applied flag.
            templateApplied = true;

            //  If we have no view model selected, we're done.
            if(ViewModel == null)
                return;

            //  Get a view for the view model.
            var view = GetViewForViewModel(ViewModel);

            //  Activate it.
            ActivateView(view);
        }

        /// <summary>
        /// The DependencyProperty for the BrokerHint property.
        /// </summary>
        private static readonly DependencyProperty BrokerHintProperty =
          DependencyProperty.Register("BrokerHint", typeof(string), typeof(ViewBroker),
          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets BrokerHint.
        /// </summary>
        /// <value>The value of BrokerHint.</value>
        public string BrokerHint
        {
            get { return (string)GetValue(BrokerHintProperty); }
            set { SetValue(BrokerHintProperty, value); }
        }

        /// <summary>   
        /// The DependencyProperty for the ViewModel property.
        /// </summary>
        private static readonly DependencyProperty ViewModelProperty =
          DependencyProperty.Register("ViewModel", typeof(object), typeof(ViewBroker),
          new PropertyMetadata(null, new PropertyChangedCallback(OnViewModelChanged)));

        /// <summary>
        /// Gets or sets ViewModel.
        /// </summary>
        /// <value>The value of ViewModel.</value>
        public object ViewModel
        {
            get { return (object)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        /// <summary>
        /// Called when ViewBroker changes.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnViewModelChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ViewBroker me = o as ViewBroker;

            //  We are only going to switch the content to the view if we're applied the template
            //  and we have a view.
            if (me.templateApplied == false)
                return;

            //  If the viewmodel is null, show the default content.
            if (me.ViewModel == null)
            {
                me.Content = me.defaultContent;
                return;
            }

            //  Get the appropriate view and activate it.
            var view = me.GetViewForViewModel(me.ViewModel);
            me.ActivateView(view);
        }

        /// <summary>
        /// Activates the view.
        /// </summary>
        /// <param name="view">The view.</param>
        private void ActivateView(object view)
        {
            //  Before we set the view as the content, if the current content is a view,
            //  we can deactivate it.
            if(Content is IView)
                ((IView)Content).OnDeactivated();

            //  Set the view as the content.
            Content = view;

            //  If the view instance implements IView, we can activate it.
            if (view is IView)
                ((IView)view).OnActivated();
        }

        /// <summary>
        /// Gets a view instance for a view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>An instance of the associated view.</returns>
        private object GetViewForViewModel(object viewModel)
        {
            //  Get the type of the view, given the broker hint.
            var viewType = ApexBroker.GetViewForViewModel(viewModel.GetType(), BrokerHint);

            //  If we don't have a type, we must throw an exception.
            if (viewType == null)
                throw new InvalidOperationException("Cannot broker a view for the view model type " + viewModel.GetType().Name);

            //  We have the view type, now we must create an instance of it.
            //  TODO: This is where we must take the re-use options into account.
            object viewInstance = Activator.CreateInstance(viewType);

            //  It must be a dependency object and framework element.
            if (viewInstance is FrameworkElement == false)
                throw new InvalidOperationException("A View must be a FrameworkElement");

            //  Return the view instance.
            return viewInstance;
        }

        /// <summary>
        /// The default content (shown when no VM is set).
        /// </summary>
        private object defaultContent;

        /// <summary>
        /// A flag indicating whether the template has been applied.
        /// </summary>
        private bool templateApplied;
    }
}
