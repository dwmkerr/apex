using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Extensions
{
  public static class StringExtensions
  {
    public static bool ContainsCaseInsensitive(this string source, string value)
    {
      int results = source.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
      return results == -1 ? false : true;
    }
  }
}
