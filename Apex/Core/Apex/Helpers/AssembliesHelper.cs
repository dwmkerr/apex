using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Apex.Helpers
{
    /// <summary>
    /// The AssembliesHelper helps gets assemblies and types used for brokering views and 
    /// viewmodels etc, in a consistent way across platforms.
    /// </summary>
    public static class AssembliesHelper
    {
        public static IEnumerable<Assembly> GetDomainAssemblies()
        {
#if SILVERLIGHT3
            
            return new List<Assembly> {Assembly.GetCallingAssembly(), Assembly.GetExecutingAssembly()};
#elif SILVERLIGHT4
            //  TODO: According to MSDN AppDomain.CurrentDomain.GetAssemblies should compile in SL4 - it doesn't seem to.
            //  We can force it to work by making things dynamic.
            dynamic appDomain = AppDomain.CurrentDomain;
            return appDomain.GetAssemblies();
#else
            return AppDomain.CurrentDomain.GetAssemblies();
#endif

        }

        /// <summary>
        /// Gets the domain types.
        /// </summary>
        /// <returns>Domain types.</returns>
        public static IEnumerable<Type> GetTypesInDomain()
        {
            
#if SILVERLIGHT3
            var typesToSearch = (from a in GetDomainAssemblies()
                                     from t in a.GetExportedTypes()
                                     select t).ToList();
#elif SILVERLIGHT4
                var typesToSearch = (from a in GetDomainAssemblies()
                                     where a.IsDynamic == false
                                     from t in a.GetExportedTypes()
                                     select t).ToList();
#elif SILVERLIGHT
                var typesToSearch = (from a in GetDomainAssemblies()
                                     where a.IsDynamic == false
                                     from t in a.GetExportedTypes()
                                     select t).ToList();
#else
                var typesToSearch = (from a in GetDomainAssemblies()
                                    where a.GlobalAssemblyCache == false && a.IsDynamic == false
                                    from t in a.GetExportedTypes()
                                    select t).ToList();
#endif
            return typesToSearch.Distinct();

        }
    }
}
