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
