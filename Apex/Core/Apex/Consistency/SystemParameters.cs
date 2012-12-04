namespace Apex.Consistency
{
    /// <summary>
    /// Provides a Silverlight/WPF independent way to get system parameters
    /// not in both platforms.
    /// </summary>
    public static class SystemParameters
    {
        /// <summary>
        /// Gets the minimum horizontal drag distance.
        /// </summary>
        public static double MinimumHorizontalDragDistance
        {
            get
            {
#if SILVERLIGHT
                return 4.0;
#else
                return System.Windows.SystemParameters.MinimumHorizontalDragDistance;
#endif
            }
        }

        /// <summary>
        /// Gets the minimum vertical drag distance.
        /// </summary>
        public static double MinimumVerticalDragDistance
        {
            get
            {
#if SILVERLIGHT
                return 4.0;
#else
                return System.Windows.SystemParameters.MinimumVerticalDragDistance;
#endif
            }
        }
    }
}