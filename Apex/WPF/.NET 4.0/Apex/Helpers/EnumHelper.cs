
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
using System.Reflection;
namespace Apex.Helpers
{

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class EnumHelper
  {
    public static object[] GetValues(Type enumType)
    {

      if (!enumType.IsEnum)
      {

        throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");

      }



      List<object> values = new List<object>();



      var fields = from field in enumType.GetFields()

                   where field.IsLiteral

                   select field;



      foreach (FieldInfo field in fields)
      {

        object value = field.GetValue(enumType);

        values.Add(value);

      }



      return values.ToArray();

    }
  }
}
