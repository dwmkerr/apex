using System;
using System.Windows.Controls;
using System.Windows;
using Apex.MVVM;

namespace Apex.Controls
{
    /// <summary>
    /// A ViewBroker takes a ViewModel and shows the appropriate View.
    /// </summary>
    public class ViewBroker : ContentControl
    {
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes 
        /// call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

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
        /// The DependencyProperty for the AllowUnknownViewModels property.
        /// </summary>
        public static readonly DependencyProperty AllowUnknownViewModelsProperty =
          DependencyProperty.Register("AllowUnknownViewModels", typeof(bool), typeof(ViewBroker),
          new PropertyMetadata(default(bool)));

        /// <summary>
        /// Gets or sets AllowUnknownViewModels.
        /// </summary>
        /// <value>The value of AllowUnknownViewModels.</value>
        public bool AllowUnknownViewModels
        {
            get { return (bool)GetValue(AllowUnknownViewModelsProperty); }
            set { SetValue(AllowUnknownViewModelsProperty, value); }
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
            
            //  If the viewmodel is null, show the default content.
            if (me.ViewModel == null)
                return;

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

            //  If we don't have a type, we must throw an exception, unless we allow this.
            if (viewType == null && AllowUnknownViewModels)
                return null;
            else if(viewType == null)
                throw new InvalidOperationException("Cannot broker a view for the view model type " + viewModel.GetType().Name);

            //  We have the view type, now we must create an instance of it.
            //  TODO: This is where we must take the re-use options into account.
            object viewInstance = Activator.CreateInstance(viewType);

            //  It must be a dependency object and framework element.
            if (viewInstance is FrameworkElement == false)
                throw new InvalidOperationException("A View must be a FrameworkElement");

            //  Set the data context.
            ((FrameworkElement) viewInstance).DataContext = viewModel;

            //  Return the view instance.
            return viewInstance;
        }
    }
}
