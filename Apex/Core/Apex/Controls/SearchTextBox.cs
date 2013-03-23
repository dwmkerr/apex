using System.Windows;

namespace Apex.Controls
{
    /// <summary>
    /// The SearchTextBox is a CueTextBox with the default cue 'Search'. It mimicks the search box found in Windows 7
    /// at the top right of the file explorer.
    /// </summary>
    public class SearchTextBox : CueTextBox
    {
        /// <summary>
        /// Initializes the <see cref="SearchTextBox"/> class.
        /// </summary>
#if !SILVERLIGHT
        static SearchTextBox()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }
#else
        public SearchTextBox()
        {
            //  Override the default style.
            DefaultStyleKey = typeof(SearchTextBox);
        }
#endif

    }
}
