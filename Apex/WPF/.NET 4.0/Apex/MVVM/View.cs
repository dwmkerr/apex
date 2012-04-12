using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Apex.MVVM
{
    /// <summary>
    /// A View is a usercontrol with a viewmodel.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public class View<TViewModel> : UserControl
    {
        /// <summary>
        /// The ViewModel dependency property.
        /// </summary>
        private static readonly DependencyProperty ViewModelProperty =
          DependencyProperty.Register("ViewModel", typeof(TViewModel), typeof(View<TViewModel>),
          new PropertyMetadata(null, new PropertyChangedCallback(OnViewModelChanged)));

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public TViewModel ViewModel
        {
            get { return (TViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        /// <summary>
        /// Called when [view model changed].
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnViewModelChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Get the caller.
            View<TViewModel> me = o as View<TViewModel>;

            //  Ensure the data context is set.
            me.DataContext = me.ViewModel;
        }
                
    }
}
