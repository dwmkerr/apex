using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.Controls;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerActivationSample
{
    [ViewModel]
    public class Page1ViewModel : ViewModel, ISelectableItem
    {
        public string Title
        {
            get { return "Page 1"; }
        }

        public void OnSelected()
        {
        }

        public void OnDeselected()
        {
        }

        private readonly NotifyingProperty isSelectedProperty = new NotifyingProperty("IsSelected", typeof(bool), default(bool));

        public bool IsSelected
        {
            get { return (bool)GetValue(isSelectedProperty); }
            set { SetValue(isSelectedProperty, value); }
        }
    }
}
