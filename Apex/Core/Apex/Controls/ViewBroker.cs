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
    public class ViewBroker : ContentControl
    {
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
        /// The DependencyProperty for the Broker property.
        /// </summary>
        private static readonly DependencyProperty BrokerProperty =
          DependencyProperty.Register("Broker", typeof(ApexBroker), typeof(ViewBroker),
          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets Broker.
        /// </summary>
        /// <value>The value of Broker.</value>
        public ApexBroker Broker
        {
            get { return (ApexBroker)GetValue(BrokerProperty); }
            set { SetValue(BrokerProperty, value); }
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

            //  If we have not yet stored the default content, do so now (this is what
            //  is shown when the view model is null).
            if(me.defaultContent == null)
                me.defaultContent = me.Content;
            
            //  As long as we have a view model, we can attempt to use the broker
            //  to get a view for it.
            if (me.ViewModel != null)
            {
                //  If we have a broker, we'll use that. Otherwise we'll use the global broker.
                ApexBroker broker = me.Broker ?? ApexBroker.GlobalBroker;

                //  Get the type of the view.
                Type viewType = broker.GetViewForViewModel(me.ViewModel.GetType(), me.BrokerHint);

                //  If we don't have a type, we must throw an exception.
                if (viewType == null)
                    throw new InvalidOperationException("Cannot broker a view for the type " + viewType.Name);

                //  We have the view type, now we must create an instance of it.
                object viewInstance = Activator.CreateInstance(viewType);

                //  In general, this type will be a View. If it is, it will have a viewmodel property.
                PropertyInfo viewModelProperty = viewType.GetProperty("ViewModel");
                if (viewModelProperty != null)
                {
                    //  Set the view model of the view to the provided view model.
                    viewModelProperty.SetValue(viewInstance, me.ViewModel, null);
                }

                //  Finally, set the view as the content.
                me.Content = viewInstance;
            }
            else
            {
                //  No view model, so go back to the default content.
                me.Content = me.defaultContent;
            }
        }

        /// <summary>
        /// The default content (shown when no VM is set).
        /// </summary>
        private object defaultContent;
    }
}
