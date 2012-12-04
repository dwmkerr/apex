using System.Windows;
using System.Windows.Markup;
using Apex.MVVM;

namespace Apex.Controls
{
    /// <summary>
    /// Item for a Pivot Control.
    /// </summary>
    [ContentProperty("Content")]
    public class PivotItem : DependencyObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PivotItem"/> class.
        /// </summary>
        public PivotItem()
        {
        }

        /// <summary>
        /// The Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof (string), typeof (PivotItem));

        /// <summary>
        /// The Content Dependency Property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof (object), typeof (PivotItem));

        /// <summary>
        /// The IsSelected dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof (bool), typeof (PivotItem),
                                                                                                   new PropertyMetadata(false));

        /// <summary>
        /// The Selected command.
        /// </summary>
        public Command selectedCommand;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return GetValue(TitleProperty) as string; }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected
        {
            get { return (bool) GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }


        /// <summary>
        /// The IsInitialPage property.
        /// </summary>
        private static readonly DependencyProperty IsInitialPageProperty =
            DependencyProperty.Register("IsInitialPage", typeof (bool), typeof (PivotItem),
                                        new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether this instance is initial page.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is initial page; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitialPage
        {
            get { return (bool) GetValue(IsInitialPageProperty); }
            set { SetValue(IsInitialPageProperty, value); }
        }
    }
}