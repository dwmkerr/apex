using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Apex.Extensions
{
  /// <summary>
  /// Extensions for the enum class.
  /// </summary>
  public static class EnumExtensions
  {
    /// <summary>
    /// Gets the description of an enumeration.
    /// </summary>
    /// <param name="me">The enumeration.</param>
    /// <returns>The value of the [Description] attribute for the enum, or the name of
    /// the enum value if there isn't one.</returns>
    public static string GetDescription(this Enum me)
    {
      //  Get the enum type.
      var enumType = me.GetType();

      //  Get the description attribute.
      var descriptionAttribute = enumType.GetField(me.ToString())
        .GetCustomAttributes(typeof(DescriptionAttribute), false)
        .FirstOrDefault() as DescriptionAttribute;

      //  Get the description (if there is one) or the name of the enum otherwise.
      return descriptionAttribute != null
        ? descriptionAttribute.Description
        : me.ToString();
    }
  }
}
