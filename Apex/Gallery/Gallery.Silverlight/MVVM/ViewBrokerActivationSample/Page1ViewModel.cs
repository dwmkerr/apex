using Apex.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerActivationSample
{
    [ViewModel]
    public class Page1ViewModel : ViewModel, ISelectableItem
    {
        public string Title
        {
            get { return "Page 1"; }
        }
        
        private readonly NotifyingProperty isSelectedProperty = new NotifyingProperty("IsSelected", typeof(bool), default(bool));

        public bool IsSelected
        {
            get { return (bool)GetValue(isSelectedProperty); }
            set { SetValue(isSelectedProperty, value); }
        }
    }
}
