using System;

namespace $rootnamespace$
{
    /// <summary>
    /// The <see cref="$safeitemrootname$"/> Singleton class.
    /// </summary>
    public sealed class $safeitemrootname$
    {
        /// <summary>
        /// The Singleton instace. Declared 'static readonly' to enforce
        /// a single instance only and lazy initialisation.
        /// </summary>
        private static readonly $safeitemrootname$ instance = new $safeitemrootname$();

        /// <summary>
        /// Initializes a new instance of the <see cref="$safeitemrootname$"/> class.
        /// Declared private to enforce a single instance only.
        /// </summary>
        private $safeitemrootname$() 
        {
        }

        /// <summary>
        /// Gets the $safeitemrootname$ Singleton Instance.
        /// </summary>
        public static $safeitemrootname$ Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
