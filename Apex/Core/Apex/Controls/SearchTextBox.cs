using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Apex.Controls
{
    /// <summary>
    /// The SearchMode enumeration allows the behaviour of a SearchTextBox's search event and
    /// command to be specified.
    /// </summary>
    public enum SearchMode
    {
        /// <summary>
        /// The search is immediate - typing in the text box will do a live search.
        /// </summary>
        Immediate,

        /// <summary>
        /// The search is activated - the user must press the search button or 'enter' to search.
        /// </summary>
        Activated
    }
    
    /// <summary>
    /// The SearchTextBox is a CueTextBox with the default cue 'Search'. It mimicks the search box found in Windows 7
    /// at the top right of the file explorer. It has two modes - Immediate and Activated.
    /// In Immediate mode, the icon in the search text box is always a magnifying glass and the search event is fired
    /// every time the text changeds. In Activated mode, the search is only activated if the magnifying glass is pressed.
    /// </summary>
    public class SearchTextBox : CueTextBox
    {
        /// <summary>
        /// Initializes the <see cref="SearchTextBox"/> class.
        /// </summary>
        static SearchTextBox()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }
        
        /// <summary>
        /// The DependencyProperty for the SearchMode property.
        /// </summary>
        public static readonly DependencyProperty SearchModeProperty =
          DependencyProperty.Register("SearchMode", typeof(SearchMode), typeof(SearchTextBox),
          new PropertyMetadata(SearchMode.Immediate));

        /// <summary>
        /// Gets or sets SearchMode.
        /// </summary>
        /// <value>The value of SearchMode.</value>
        public SearchMode SearchMode
        {
            get { return (SearchMode)GetValue(SearchModeProperty); }
            set { SetValue(SearchModeProperty, value); }
        }
    }
}
