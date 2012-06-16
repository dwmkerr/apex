
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
using System.Reflection;

namespace Apex.Helpers
{

    /// <summary>
    /// The enumeration helper class.
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Gets the enumeration values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns></returns>
        public static object[] GetValues(Type enumType)
        {
            //  Sanity check.
            if (!enumType.IsEnum)
                throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");

            //  Get the fields.
            var fields = from field in enumType.GetFields()
                         where field.IsLiteral
                         select field;

            //  Get the values.
            return fields.Select(field => field.GetValue(enumType)).ToArray();

        }
    }
}