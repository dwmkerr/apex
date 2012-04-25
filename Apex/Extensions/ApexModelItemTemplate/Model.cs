using System;
using Apex.MVVM;

namespace $rootnamespace$
{
    /// <summary>
    /// The <see cref="$safeitemrootname$"/> Model Singleton class.
    /// This class implements the <see cref="I$safeitemrootname$"/> Model interface.
    /// You can retrieve the model with:
    /// <code>I$safeitemrootname$ model = ApexBroker.GetModel<I$safeitemrootname$>()</code>
    /// </summary>
    public sealed class $safeitemrootname$ : I$safeitemrootname$
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
            //  Register the model with the global broker.
            ApexBroker.RegisterModel<I$safeitemrootname$>(this);
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
