using Apex.MVVM;
using System.Collections.ObjectModel;
using Apex.Controls;

namespace $safeprojectname$.Pages
{
    [ViewModel]
    public class PageViewModel : ViewModel, ISelectableItem
    {
        public void OnSelected()
        {
        }

        public void OnDeselected()
        {
        }

        /// <summary>
        /// The NotifyingProperty for the Title property.
        /// </summary>
        private readonly NotifyingProperty TitleProperty =
          new NotifyingProperty("Title", typeof(string), default(string));

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        /// <value>The value of Title.</value>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// The NotifyingProperty for the IsSelected property.
        /// </summary>
        private readonly NotifyingProperty IsSelectedProperty =
          new NotifyingProperty("IsSelected", typeof(bool), default(bool));

        /// <summary>
        /// Gets or sets IsSelected.
        /// </summary>
        /// <value>The value of IsSelected.</value>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        /// <summary>
        /// The Pages observable collection.
        /// </summary>
        private readonly ObservableCollection<PageViewModel> PagesProperty =
          new ObservableCollection<PageViewModel>();

        /// <summary>
        /// Gets the Pages observable collection.
        /// </summary>
        /// <value>The Pages observable collection.</value>
        public ObservableCollection<PageViewModel> Pages
        {
            get { return PagesProperty; }
        }     

        /// <summary>
        /// The NotifyingProperty for the ActivePage property.
        /// </summary>
        private readonly NotifyingProperty ActivePageProperty =
          new NotifyingProperty("ActivePage", typeof(PageViewModel), default(PageViewModel));

        /// <summary>
        /// Gets or sets ActivePage.
        /// </summary>
        /// <value>The value of ActivePage.</value>
        public PageViewModel ActivePage
        {
            get { return (PageViewModel)GetValue(ActivePageProperty); }
            set { SetValue(ActivePageProperty, value); }
        }
    }
}
