using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Extensions
{
  /// <summary>
  /// A set of useful extensions for the String class.
  /// </summary>
  public static class StringExtensions
  {
    /// <summary>
    /// Determines whether the source string contains the value string, in a case-insensitive fasion.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="value">The value string.</param>
    /// <returns>
    ///   <c>true</c> if source contains value; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsCaseInsensitive(this string source, string value)
    {
      int results = source.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
      return results == -1 ? false : true;
    }
  }
}
